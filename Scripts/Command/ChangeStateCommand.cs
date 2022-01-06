using QFramework;

namespace HTCDemo
{
    public class ChangeStateCommand : AbstractCommand
    {
        private readonly GameState mState;
        private readonly int mScore;

        public ChangeStateCommand(GameState State, int Score)
        {
            mState = State;
            mScore = Score;
        }

        protected override void OnExecute()
        {
            this.GetSystem<IScoreSystem>().ChangeState(mState,mScore);
        }
    }
}