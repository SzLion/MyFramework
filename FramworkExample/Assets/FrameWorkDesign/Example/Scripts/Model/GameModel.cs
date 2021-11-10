namespace FrameworkDesign.Example
{
    public interface IGameModel
    {
        BandableProperty<int> KillCount { get; }
        BandableProperty<int> Gold { get; }
        BandableProperty<int> Score { get; }
        BandableProperty<int> BestScore { get; }
    }
    public class GameModel:IGameModel
    {  
       


        public BandableProperty<int> KillCount { get; } = new BandableProperty<int>()
        {
            Value = 0
        };

        public  BandableProperty<int> Gold { get; } = new BandableProperty<int>()
        {
            Value = 0
        };

        public  BandableProperty<int> Score { get; } = new BandableProperty<int>()
        {
            Value = 0
        };

        public  BandableProperty<int> BestScore { get; } = new BandableProperty<int>()
        {
            Value = 0
        };
    }
}