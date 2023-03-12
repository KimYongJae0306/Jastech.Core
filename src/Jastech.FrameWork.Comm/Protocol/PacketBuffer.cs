using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Comm.Protocol
{
    public class PacketBuffer
    {
        #region 속성 
        private const int MAXSIZE = 4096;

        public byte[] FullData { get; private set; }

        public bool Empty { get => FullData == null; }
        #endregion

        #region 메서드 
        public void AppendData(byte[] data, int numData)
        {
            int numDataFull = 0;
            if (FullData != null)
                numDataFull = FullData.Length;

            byte[] tempBuf = new byte[numDataFull + numData];

            if (FullData != null)
                Array.Copy(FullData, 0, tempBuf, 0, numDataFull);

            Array.Copy(data, 0, tempBuf, numDataFull, numData);

            FullData = tempBuf;
        }

        public void RemoveData(int numData)
        {
            int numDataFull = FullData.Length;

            if ((numDataFull - numData) > 0)
            {
                byte[] tempBuf = new byte[numDataFull - numData];
                Array.Copy(FullData, numData, tempBuf, 0, numDataFull - numData);
                FullData = tempBuf;
            }
            else
            {
                FullData = null;
            }
        }

        public void Clear()
        {
            FullData = null;
        }

        public override string ToString()
        {
            return System.Text.Encoding.Default.GetString(FullData);
        }

        public string GetString(int maxLen)
        {
            string fullString = System.Text.Encoding.Default.GetString(FullData);
            int strLen = Math.Min(fullString.Length, maxLen);

            return fullString.Substring(0, strLen);
        }
        #endregion
    };
}
