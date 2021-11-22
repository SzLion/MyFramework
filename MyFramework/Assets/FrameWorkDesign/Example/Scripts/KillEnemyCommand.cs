namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        public override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();
            gameModel.KillCount.Value++;
            if (gameModel.KillCount.Value == 9)
            {
                this.SendEvent<GamePassEvent>();
            }
        }
    }
}