using QFramework;

namespace HTCDemo
{
    public class SubScoreCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var scoreSystem = this.GetSystem<IScoreSystem>();
            if (scoreSystem.CurrentState.Score > 0)
            {
                scoreSystem.CurrentState.Score.Value--;
                this.SendEvent<OnSubCurrentScore>(new OnSubCurrentScore()
                {
                    mState = scoreSystem.CurrentState.CurrentState.Value,
                    mCurrentScore = scoreSystem.CurrentState.Score.Value
                });
            }
        }
    }

    public class OnSubCurrentScore
    {
        public GameState mState { get; set; }
        public int mCurrentScore { get; set; }
    }
}