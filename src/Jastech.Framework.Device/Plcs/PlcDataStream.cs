using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Plcs
{
    public enum MessageType
    {
        Read,
        Write,
    }

    public class PlcDataStream
    {
        #region 필드
        private StringBuilder _dataList = new StringBuilder();
        #endregion

        #region 속성
        public byte[] Data { get => Encoding.UTF8.GetBytes(_dataList.ToString()); }

        public string DataAsString { get => _dataList.ToString(); }
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public void ClearData()
        {
            _dataList.Clear();
        }

        public void AddData(byte[] byteData)
        {
            string hexStr = "";
            foreach (byte bt in byteData)
            {
                hexStr += ((int)bt).ToString("X2");
            }
            _dataList.Append(hexStr);
        }

        public void AddSwapData(byte[] byteData)
        {
            string hexStr = "";
            for (int i = 1; i >= 0; i--)
            {
                hexStr += ((int)byteData[i]).ToString("X2");
            }
            _dataList.Append(hexStr);
        }

        // ok
        public void AddSwap32BitData(int value)
        {
            string hexStr = "";
            byte[] valueByte = BitConverter.GetBytes(value);
            for (int i = 0; i < 4; i++)
            {
                hexStr += ((int)valueByte[i]).ToString("X2");
            }

        }

        // ok
        public void Add32BitData(int value)
        {
            string hexStr = "";
            byte[] valueByte = BitConverter.GetBytes(value);
            for (int i = 3; i >= 0; i--)
            {
                hexStr += ((int)valueByte[i]).ToString("X2");
            }
        }
        #endregion
    }
}
