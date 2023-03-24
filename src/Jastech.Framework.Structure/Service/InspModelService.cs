using Jastech.Framework.Structure.Service;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Structure.Service
{
    public abstract class InspModelService : IInspModelService
    {
        #region 필드
        private InspModel _currentInspModel;
        #endregion

        #region 속성
        public InspModel CurrentInspModel
        {
            get => _currentInspModel;
            set
            {
                if (ReferenceEquals(_currentInspModel, value))
                    return;

                InspModel prevInspModel = _currentInspModel;
                _currentInspModel = value;
            }
        }
        #endregion

        #region 메서드
        public abstract InspModel New();

        public abstract InspModel Load(string filePath);
        #endregion
    }
}
