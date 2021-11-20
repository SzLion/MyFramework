namespace FrameworkDesign
{
    public interface IModel : IBelongToArchitecture, ICanSetArchitecture,ICanGetUtility
    {
        void init();
    }
    public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture = null;
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }

        void IModel.init()
        {
            OnInit();
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        protected abstract void OnInit();
    }
}