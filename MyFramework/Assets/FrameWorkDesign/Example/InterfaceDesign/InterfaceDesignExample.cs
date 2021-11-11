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
        /// �ӿڵ���ʽʵ��
        /// </summary>
        public void SayHello()
        {
            Debug.Log("Hello");
        }
        /// <summary>
        /// �ӿڵ���ʽʵ��
        /// </summary>
        void ICanSayHello.SayOther() 
        {
            Debug.Log("Other");
        }

        // Start is called before the first frame update
        void Start()
        {
            //��ʽʵ�ֵĽӿڿ���ͨ������ֱ�ӵ���
            this.SayHello();
            //��ʽʵ�ֵĽӿڲ���ͨ������ֱ�ӵ��ã�����ͨ���ӿڶ������
            (this as ICanSayHello).SayOther();
        }

       
    }
}