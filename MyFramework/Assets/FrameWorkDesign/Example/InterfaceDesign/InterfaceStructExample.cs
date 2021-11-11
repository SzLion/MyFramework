using UnityEngine;
namespace FrameworkDesign.Example
{
    public class InterfaceStructExample : MonoBehaviour
    {
        public interface ICustomScript
        {
            void Start();
            void Excute();
            void Destroy();
        }
        public abstract class CustomScript : ICustomScript
        {
            protected bool mStarted { get; private set; }
            protected bool mDestroyed { get; private set; }
            /// <summary>
            /// 不希望子类访问Start方法，因为可能破坏状态
            /// </summary>
            void ICustomScript.Destroy()
            {
                OnDestroy();
                mDestroyed = true;
            }

            void ICustomScript.Excute()
            {
                OnExcute();
            }

            void ICustomScript.Start()
            {
                OnStart();
                mStarted = true;
            }
            protected abstract void OnStart();
            protected abstract void OnExcute();
            protected abstract void OnDestroy();

        }
        public class MyScript : CustomScript
        {
            protected override void OnDestroy()
            {
                Debug.Log("MyScript:OnDestroy");
            }

            protected override void OnExcute()
            {
                Debug.Log("MyScript:OnExcute");
            }

            protected override void OnStart()
            {
                Debug.Log("MyScript:OnStart");
            }
        }
        // 测试脚本
        void Start()
        {
            ICustomScript script = new MyScript();
            script.Start();
            script.Excute();
            script.Destroy();
        }

     
    }
}