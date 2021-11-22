namespace FrameworkDesign.Example
{
    public class GameStartCommand : AbstractCommand
    {
        public override void OnExecute()
        {
            this.SendEvent<GameStartEvent>();
        }
    }
}