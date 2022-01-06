using QFramework;

namespace HTCDemo
{
    public class CurrentScoreQuery : AbstractQuery<int>
    {
        protected override int OnDo()
        {
           return this.GetModel<IScoreModel>().CurrentScore.Value;
        }
    }
}