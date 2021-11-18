using FrameworkDesign;
namespace CounterApp
{
    public class AddCountCommand : AbstractCommand
    {
        public override void OnExecute()
        {
            this.GetModel<ICounterModel>().Count.Value++;
        }      
    }
}