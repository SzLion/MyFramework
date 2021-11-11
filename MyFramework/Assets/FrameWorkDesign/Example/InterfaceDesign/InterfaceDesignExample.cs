using UnityEngine;
namespace FrameworkDesign.Example
{
    public interface ICanSayHello
    {
        void SayHello();
        void SayOther();
    };
    public class InterfaceDesignExample : MonoBehaviour,ICanSayHello
    {
        /// <summary>
        /// 接口的隐式实现
        /// </summary>
        public void SayHello()
        {
            Debug.Log("Hello");
        }
        /// <summary>
        /// 接口的显式实现
        /// </summary>
        void ICanSayHello.SayOther() 
        {
            Debug.Log("Other");
        }

        // Start is called before the first frame update
        void Start()
        {
            //隐式实现的接口可以通过对象直接调用
            this.SayHello();
            //显式实现的接口不能通过对象直接调用，必须通过接口对象调用
            (this as ICanSayHello).SayOther();
        }

       
    }
}