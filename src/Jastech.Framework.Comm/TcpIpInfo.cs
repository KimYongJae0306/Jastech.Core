using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm
{
    public class TcpIpInfo
    {
        #region 생성자 
        public TcpIpInfo()
        {
            IpAddress = "127.0.0.1";
            PortNo = 4000;
        }

        public TcpIpInfo(string ipAddress, int portNo)
        {
            this.IpAddress = ipAddress;
            this.PortNo = portNo;
        }
        #endregion


        #region 속성 
        [JsonProperty]
        public string IpAddress { get; set; }

        [JsonProperty]
        public int PortNo { get; set; }
        #endregion


        #region 메서드 
        public TcpIpInfo Clone()
        {
            TcpIpInfo tcpIpInfo = new TcpIpInfo();
            tcpIpInfo.IpAddress = this.IpAddress;
            tcpIpInfo.PortNo = this.PortNo;
            return tcpIpInfo;
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", IpAddress, PortNo);
        }
        #endregion
    }
}
