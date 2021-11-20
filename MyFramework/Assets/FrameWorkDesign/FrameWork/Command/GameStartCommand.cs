namespace FrameworkDesign.Example
{
    public class GameStartCommand : AbstractCommand 
    {
        public override void OnExecute()
        {
            GameStartEvent.Trigger();
        }
    }
}