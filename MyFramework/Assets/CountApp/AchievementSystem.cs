using UnityEngine;
using CounterApp;
namespace FrameworkDesign
{
    public interface IAchievementSystem:ISystem 
    {

    }

    public class AchievementSystem : IAchievementSystem
    {
        public IArchitecture Architecture { get; set; }

        public void init()
        {
            var counterModel = Architecture.GetModel<ICounterModel>();
            var previousCount = counterModel.Count.Value;

            counterModel.Count.OnValueChanged += newCount =>
          {
              if (newCount >= 10 && previousCount<10)
              {
                  Debug.Log("����10�ε���ɾ�");
              }
              else if (newCount >= 20 && previousCount <20)
              {
                  Debug.Log("����20�ε���ɾ�");
              }
              previousCount = newCount;
          };
        }
    }
}