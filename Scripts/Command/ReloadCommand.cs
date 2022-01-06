using QFramework;

namespace HTCDemo
{
    public class ReloadCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendCommand(new ChangeStateCommand(GameState.Step1, 1));
        }
    }
}