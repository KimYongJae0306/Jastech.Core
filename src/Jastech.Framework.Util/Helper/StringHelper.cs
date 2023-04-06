using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Util.Helper
{
    public static class StringHelper
    { 
        /// <summary>
        /// 문자열을 바이트 배열로 변환
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToByte(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
