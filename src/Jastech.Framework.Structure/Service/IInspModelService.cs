namespace Jastech.Framework.Structure.Service
{
    public interface IInspModelService
    {
        #region 속성
        InspModel CurrentInspModel { get; set; }

        void AddModelData(InspModel inspModel);
        #endregion

        #region 메서드
        InspModel New();
        #endregion
    }
}
