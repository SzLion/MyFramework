using QFramework;

namespace HTCDemo
{
    public class CompletedCommand : AbstractCommand

    {
        protected override void OnExecute()
        {
            var scoreSystem = this.GetSystem<IScoreSystem>();
            var scoreModel = this.GetModel<IScoreModel>();
            scoreModel.TotalScore.Value += scoreSystem.CurrentState.Score.Value;
        }
    }
}