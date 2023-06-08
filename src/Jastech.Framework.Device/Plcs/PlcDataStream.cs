using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Plcs
{
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
        #endregion
    }
}
