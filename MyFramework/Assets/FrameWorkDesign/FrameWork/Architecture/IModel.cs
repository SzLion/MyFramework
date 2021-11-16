namespace FrameworkDesign
{
    public interface IModel : IBelongToArchitecture, ICanSetArchitecture
    {
        void init();
    }
    public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture = null;
        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        void IModel.init()
        {
            OnInit();
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        protected abstract void OnInit();
    }
}