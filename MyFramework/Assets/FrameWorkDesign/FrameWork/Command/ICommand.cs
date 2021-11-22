namespace FrameworkDesign
{
    public interface ICommand : IBelongToArchitecture, ICanSetArchitecture, ICanGetModel, ICanGetSystem, ICanGetUtility,ICanSendEvent,ICanSendCommand
    {
        void Execute();
    }

    public abstract class AbstractCommand : ICommand
    {
        IArchitecture mArchitecture = null;
        void ICommand.Execute()
        {
            OnExecute();
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        public abstract void OnExecute();
    }
}