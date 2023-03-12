using Jastech.Framework.Imaging.Matrox;
using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Device.Grabbers
{
    public class MILFrameGrabber : Grabber
    {
        #region 필드
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public override ConnectionStatus Initialize()
        {
            
        }

        public ConnectionStatus Initialize(bool isSimautionMode, string boardType, ref int boardID)
        {
            MIL.MappAlloc(MIL.M_DEFAULT, ref _milApplication);
            MIL.MappControl(MIL.M_ERROR, MIL.M_PRINT_DISABLE);

            return ConnectionStatus.Fail;
            //this._isSimualtionMode = isSimautionMode;

            //if (MIL.M_NULL == _milApplication && _isSimualtionMode == false)
            //{
            //    if (MIL.M_NULL == MIL.MappAlloc(MIL.M_DEFAULT, ref _milApplication))
            //        return eConnectionStatus.Connection_Fail;
            //}

            //MIL.MappControl(MIL.M_ERROR, MIL.M_PRINT_DISABLE);

            //if (Main.DEFINE.USE_CONTINUOUS)
            //    MIL.MappControl(MIL.M_GRAB_MODE, MIL.M_CONTIGUOUS);

            //int foundBoardCount = (int)MIL.MappInquire(MIL.M_INSTALLED_SYSTEM_COUNT);

            //if (foundBoardCount < 1)
            //    return eConnectionStatus.Connection_NotFound_Board;
            //for (int i = 0; i < Main.DEFINE.nScan_Max_Cnt; i++)
            //{
            //    for (int j = 0; j < Main.DEFINE.nMaxScene; j++)
            //    {
            //        _UserHookData.m_arrlistSceneState[i] = new List<int>();
            //        _UserHookData.m_arrlistSceneState[i].Add(0);
            //        _UserHookData.m_arrlistTabStartLine[i] = new List<int>();
            //        _UserHookData.m_arrlistTabStartLine[i].Add(0);
            //        _UserHookData.m_arrlistSceneState[i] = new List<int>();
            //        _UserHookData.m_arrlistSceneState[i].Add(0);
            //        _UserHookData.m_arrlistTabEndLine[i] = new List<int>();
            //        _UserHookData.m_arrlistTabEndLine[i].Add(0);
            //    }
            //}
            //for (int i = 0; i < foundBoardCount; i++)
            //{
            //    StringBuilder foundBoardName = new StringBuilder();
            //    MIL.MappInquire(MIL.M_INSTALLED_SYSTEM_DESCRIPTOR + i, foundBoardName);

            //    List<Char> removeCharacter = new List<char>() { '{', '}' };

            //    if (string.Compare(boardType, StringFilter(foundBoardName.ToString(), removeCharacter).ToString(), true) == 0)
            //    {
            //        if (MIL.MsysAlloc(boardType, MIL.M_DEV0, MIL.M_COMPLETE, ref _milSystem[i]) != MIL.M_NULL)
            //        {
            //            boardID = i;
            //            return eConnectionStatus.Connection_Success;
            //        }
            //    }
            //}

            //return eConnectionStatus.Connection_Fail;
        }
        #endregion

    }
}
