using QFramework;

namespace HTCDemo
{
    public class TotalScoreQuery : AbstractQuery<int>
    {
        
        protected override int OnDo()
        {
            var scoreModel = this.GetModel<IScoreModel>();
            return scoreModel.TotalScore.Value;
        }
    }
}