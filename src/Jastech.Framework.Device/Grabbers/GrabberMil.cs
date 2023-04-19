using Jastech.Framework.Matrox;
using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Grabbers
{
    public enum MilSystemType
    {
        Solios,
        Rapixo,
    }
    public partial class GrabberMil : Grabber
    {
        #region 필드
        private int MaxScanCount { get; set; } = 4;

        const int BufferPoolCount = 10;
        #endregion

        #region 속성
        public static List<MilSystem> MilSystemList { get; set; } = new List<MilSystem>();
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public GrabberMil() : base()
        {

        }

        #endregion

        #region 메서드
        public override void Initialize()
        {
            MilHelper.InitApplication();
        }

        public override void Release()
        {
            foreach (MilSystem milSystem in MilSystemList)
            {
                MIL.MsysFree(milSystem.SystemId);
            }
        }

        public static MilSystem GetMilSystem(MilSystemType systemType, uint systemNum)
        {
            string systemDescriptor = GetSystemDescriptor(systemType);

            return GetMilSystem(systemDescriptor, systemNum);
        }

        static string GetSystemDescriptor(MilSystemType systemType)
        {
            switch (systemType)
            {
                case MilSystemType.Solios:
                    return MIL.M_SYSTEM_SOLIOS;
                case MilSystemType.Rapixo:
                    return MIL.M_SYSTEM_RADIENTCXP;
            }

            return MIL.M_SYSTEM_SOLIOS;
        }

        static MilSystem GetMilSystem(string systemDescriptor, uint systemNum)
        {
            MilSystem milSystem = MilSystemList.Find(x => x.SystemDescriptor == systemDescriptor && x.SystemNum == systemNum);
            if (milSystem == null)
                milSystem = CreateMilSystem(systemDescriptor, systemNum);

            return milSystem;
        }

        static MilSystem CreateMilSystem(string systemDescriptor, uint systemNum)
        {
            MilSystem milSystem = null;

            MIL_ID systemId = MIL.M_NULL;

            //StringBuilder foundBoardName = new StringBuilder();
            //MIL.MappInquire(MIL.M_INSTALLED_SYSTEM_DESCRIPTOR + 0, foundBoardName);
            //if (MIL.MsysAlloc("M_SYSTEM_RAPIXOCXP", MIL.M_DEV0, MIL.M_COMPLETE, ref systemId) != MIL.M_NULL)
            //{

            //}
                if (MIL.MsysAlloc("M_SYSTEM_RAPIXOCXP", systemNum, MIL.M_DEFAULT, ref systemId) == MIL.M_NULL)
            {
                //LogHelper.Error(String.Format("Can't Allocate MIL System. {0}, {1}", systemDescriptor, systemNum));
            }
            else
            {
                milSystem = new MilSystem();
                milSystem.SystemDescriptor = "M_SYSTEM_RAPIXOCXP";// systemDescriptor;
                milSystem.SystemNum = systemNum;
                milSystem.SystemId = systemId;
            }

            return milSystem;
        }
        #endregion

    }

    public class MilSystem
    {
        public string SystemDescriptor { get; set; }

        public uint SystemNum { get; set; }

        public MIL_ID SystemId { get; set; }
    }
}
