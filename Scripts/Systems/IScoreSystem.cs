using System;
using QFramework;

namespace HTCDemo
{
    public interface IScoreSystem : ISystem
    {
        StateInfo CurrentState { get; }
        void ChangeState(GameState state, int StateScore);
    }

    public class OnStateChanged
    {
        public GameState mState { get; set; }
        public int mCurrentScore { get; set; }
    }

    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        protected override void OnInit()
        {
            scoreModel = this.GetModel<IScoreModel>();
        }


        public StateInfo CurrentState { get; } = new StateInfo()
        {
            CurrentState = new BindableProperty<GameState>()
            {
                Value = GameState.Step1
            },
            Score = new BindableProperty<int>()
            {
                Value = 1
            },
        };

        private IScoreModel scoreModel;

        /// <summary>
        /// 状态切换
        /// </summary>
        /// <param name="mGameState">切换去的状态</param>
        /// <param name="StateScore">此状态分数</param>
        public void ChangeState(GameState mGameState, int StateScore)
        {
            if (CurrentState.CurrentState.Value == mGameState)
            {
                return;
            }
            else
            {
                if (mGameState == GameState.Step1)
                {
                    this.GetModel<IScoreModel>().TotalScore.Value = 0;
                    CurrentState.CurrentState.Value = GameState.Step1;
                    CurrentState.Score.Value = 1;
                }
                else
                {
                    scoreModel.TotalScore.Value += CurrentState.Score.Value;
                    scoreModel.CurrentScore.Value = CurrentState.Score.Value;
                    CurrentState.CurrentState.Value = mGameState;
                    CurrentState.Score.Value = StateScore;
                }
            }

            this.SendEvent(new OnStateChanged()
            {
                mState = CurrentState.CurrentState.Value,
                mCurrentScore = CurrentState.Score.Value
            });
        }
    }
}