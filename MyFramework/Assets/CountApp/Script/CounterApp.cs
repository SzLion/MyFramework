using FrameworkDesign;
namespace CounterApp
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
            RegisterModel<ICounterModel>(new CounterModel());
        }
    }
}