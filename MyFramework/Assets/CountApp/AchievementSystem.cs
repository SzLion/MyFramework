using UnityEngine;
using CounterApp;
namespace FrameworkDesign
{
    public interface IAchievementSystem:ISystem 
    {

    }

    public class AchievementSystem :AbstractISystem, IAchievementSystem
    {      

        protected override void OnInit()
        {
            var counterModel = GetArchitecture().GetModel<ICounterModel>();
            var previousCount = counterModel.Count.Value;

            counterModel.Count.OnValueChanged += newCount =>
            {
                if (newCount >= 10 && previousCount < 10)
                {
                    Debug.Log("����10�ε���ɾ�");
                }
                else if (newCount >= 20 && previousCount < 20)
                {
                    Debug.Log("����20�ε���ɾ�");
                }
                previousCount = newCount;
            };
        }
    }
}