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
            /// ��ϣ���������Start��������Ϊ�����ƻ�״̬
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
        // ���Խű�
        void Start()
        {
            ICustomScript script = new MyScript();
            script.Start();
            script.Excute();
            script.Destroy();
        }

     
    }
}