using QFramework;

namespace HTCDemo
{
    public enum GameState
    {
        Step1,
        Step2,
        Step3,
        Step4,
        Step5
    }

    public class StateInfo
    {
        public BindableProperty<int> Score;

        public BindableProperty<GameState> CurrentState;
    }
}