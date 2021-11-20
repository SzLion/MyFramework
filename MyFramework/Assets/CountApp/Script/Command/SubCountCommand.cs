using FrameworkDesign;
namespace CounterApp
{
    public class SubCountCommand : AbstractCommand
    {
        public override void OnExecute()
        {
            this.GetModel<ICounterModel>().Count.Value--;
        }
    }
}