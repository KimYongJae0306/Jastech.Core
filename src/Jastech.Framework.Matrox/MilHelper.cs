using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Matrox
{
    public static class MilHelper
    {
        private static MIL_ID ApplicationId { get; set; } = MIL.M_NULL;

        private static Dictionary<long, Action<MIL_ID>> DisposingActionMap { get; } = new Dictionary<long, Action<MIL_ID>>();

        public static bool InitApplication()
        {
            try
            {
                if (ApplicationId == MIL.M_NULL)
                {
                    //Logger.Debug(LoggerType.Imaging, "Initialize MIL Applications");
                    MIL_ID applicationId = MIL.M_NULL;
                    MIL.MappAlloc(MIL.M_NULL, MIL.M_DEFAULT, ref applicationId);
                    ApplicationId = applicationId;
                    MIL.MappControl(ApplicationId, MIL.M_ERROR, MIL.M_PRINT_DISABLE);
#if DEBUG == true
                    MIL.MappControl(ApplicationId, MIL.M_ERROR, MIL.M_PRINT_ENABLE);
#endif
                }
            }
            catch (Exception)
            {
                if (ApplicationId == MIL.M_NULL)
                {
                    //Logger.Info(LoggerType.Imaging, "[MatroxHelper.InitApplication] Can't allocation MIL application. Maybe, MILL is not installed.");
                }
                return false;
            }

            return true;
        }

        public static void FreeApplication()
        {
            foreach (var pair in DisposingActionMap)
            {
                pair.Value.Invoke(pair.Key);
            }
            DisposingActionMap.Clear();
            if (ApplicationId != MIL.M_NULL)
            {
                //Logger.Debug(LoggerType.Imaging, "Free MIL Applications");
                MIL.MappFree(ApplicationId);
                ApplicationId = MIL.M_NULL;
            }
        }
    }
}
