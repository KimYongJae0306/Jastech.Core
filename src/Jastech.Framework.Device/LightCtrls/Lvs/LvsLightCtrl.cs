﻿using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Jastech.Framework.Device.LightCtrls.Lvs.Parser;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace Jastech.Framework.Device.LightCtrls.Lvs
{
    public class LvsLightCtrl : LightCtrl
    {
        #region 속성
        public ILvsParser Parser { get; set; }
        #endregion

        #region 생성자
        public LvsLightCtrl(string name, int totalChannelCount, IComm comm, ILvsParser lvsParser)
           : base(name, totalChannelCount, comm)
        {
            Parser = lvsParser;
        }
        #endregion

        #region 메서드
        public override bool Initialize()
        {
            if (Communition.GetType() == typeof(SerialPortComm))
            {
                if (Parser.GetType() == typeof(LvsSerialParser))
                {
                    Protocol = new StxEtxProtocol(new byte[] { 0x01 }, new byte[] { 0x04 }, new byte[] { }, new byte[] { 0x06 });
                }
            }
            Communition.Received += Communition_Received;

            return base.Initialize();// Communition Initalize
        }

        public override bool IsConnected()
        {
            return Communition.IsConnected();
        }

        private void Communition_Received(byte[] data)
        {
            //DataReceivedEvent.Set();
        }

        public override bool Release()
        {
            Communition.Received -= Communition_Received;
            return base.Release();
        }

        public override bool TurnOn()
        {
            // Lvs 전체 On/off만 하는 통신 프로토콜이 존재 하지 않음
            return true;
        }

        public override bool TurnOn(int channel)
        {
            // Lvs 조명 컨트롤러는 Channel로만 On하는 통신 프로토콜이 존재 하지 않음
            return true;
        }


        public override bool TurnOff()
        {
            bool isSuccess = true;
            for (int i = 0; i < TotalChannelCount; i++)
            {
                isSuccess |= TurnOff(i);
            }
            return isSuccess;
        }

        public override bool TurnOff(int channel)
        {
            if (SendSelectChannel(channel) == false)
                return false;

            return SendLightPacket(channel, 0);
        }

        public override bool TurnOn(LightValue lightValue)
        {
            bool result = true;
            for (int channel = 0; channel < TotalChannelCount; channel++)
            {
                result |= TurnOn(channel, lightValue.Get(channel));
            }
            return result;
        }

        public override bool TurnOn(int channel, int level)
        {
            if (SendSelectChannel(channel) == false)
                return false;

            return SendLightPacket(channel, level);
        }

        public bool SendSelectChannel(int channel)
        {
            byte channelBit = new byte();
            channelBit += (byte)Math.Pow(2, channel - 1);

            byte[] dataArray = new byte[4];
            Parser.OpMode = 0x00;                        // [OPMode] Write : 0x00, Read : 0x01
            Parser.DataLength = 0x01;                        // [DataLength]
            Parser.Address = 0x20;                        // [Address] Channel Select Register : 0x20 
            Parser.Value = channelBit;                  // Channel

            Parser.Serialize(out byte[] serializedData);
            if (Protocol.MakePacket(serializedData, out byte[] sendData))
            {
                Communition.Send(sendData);
            }
            return true;
        }

        public bool SendLightPacket(int channel, int level)
        {
            Parser.OpMode = 0x00;                    // [OPMode] Write : 0x00, Read : 0x01
            Parser.DataLength = 0x01;                    // [DataLength]
            Parser.Address = 0x28;                    // [Address] Step Value Register : 0x28
            Parser.Value = Convert.ToByte(level);   // Light level

            Parser.Serialize(out byte[] serializedData);
            if (Protocol.MakePacket(serializedData, out byte[] sendData))
            {
                Communition.Send(sendData);
            }
            return true;
        }
        #endregion
    }
}
