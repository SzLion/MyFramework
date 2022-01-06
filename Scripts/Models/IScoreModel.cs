using QFramework;

namespace HTCDemo
{
    public interface IScoreModel : IModel
    {
        BindableProperty<int> TotalScore { get; }
        BindableProperty<int> CurrentScore { get; }
    }

    public class ScoreModel : AbstractModel, IScoreModel
    {
        protected override void OnInit()
        {
        }

        public BindableProperty<int> TotalScore { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> CurrentScore { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}