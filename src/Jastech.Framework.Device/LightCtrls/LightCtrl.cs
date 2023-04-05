using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LightCtrls
{
    public abstract partial class LightCtrl : IDevice
    {
        #region 필드
        #endregion

        #region 속성
        [JsonProperty]
        public int MaxLightLevel { get; protected set; } = 255;

        [JsonProperty]
        public int NumChannel { get; protected set; }
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public LightCtrl(string name, int numChannel)
        {
            Name = name;
            NumChannel = numChannel;
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 컨트롤에 연결된 조명 전체를 켠다.
        /// </summary>
        /// <returns></returns>
        public abstract bool TurnOn();

        /// <summary>
        /// 컨트롤에 연결된 조명 전체를 끈다.
        /// </summary>
        /// <returns></returns>
        public abstract bool TurnOff();

        public abstract bool TurnOn(int channel, int level);

        public abstract bool TurnOff(int channel, int level);
        #endregion
    }

    public abstract partial class LightCtrl : IDevice
    {
        #region 속성
        public string Name { get; protected set; }
        #endregion

        #region 메서드
        public virtual bool Initialize()
        {
            return true;
        }

        public virtual bool Release()
        {
            return true;
        }
        #endregion
    }
}
