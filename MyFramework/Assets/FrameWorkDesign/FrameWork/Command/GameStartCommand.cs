namespace FrameworkDesign.Example
{
    public struct GameStartCommand : ICommand
    {
        public void Execute()
        {
            GameStartEvent.Trigger();
        }
    }
}