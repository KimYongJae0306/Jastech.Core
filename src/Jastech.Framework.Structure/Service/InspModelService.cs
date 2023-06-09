﻿namespace Jastech.Framework.Structure.Service
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

        public abstract void AddModelData(InspModel inspModel);

        public abstract InspModel Load(string filePath);

        public abstract void Save(string filePath, InspModel model);

        public abstract void SaveExceptVpp(string filePath, InspModel model);
        #endregion
    }
}
