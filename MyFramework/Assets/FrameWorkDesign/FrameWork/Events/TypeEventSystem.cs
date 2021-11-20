using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    public interface ITypeEventSystem
    {
        /// <summary>
        /// �����¼� 
        /// </summary>
        void Send<T>() where T : new();
        void Send<T>(T e);

        /// <summary>
        /// ע���¼�
        /// </summary>
        IUnRegister Register<T>(Action<T> onEvent);

        /// <summary>
        /// ע���¼�
        /// </summary>
        void UnRegister<T>(Action<T> onEvent);
    }

    /// <summary>
    /// ����ע���Ľӿ�
    /// </summary>
    public interface IUnRegister
    {
        void UnRegister();
    }

    /// <summary>
    /// ע���ӿڵ�ʵ��
    /// </summary>
    public class TypeEventSystemUnRegister<T> : IUnRegister
    {
        public ITypeEventSystem TypeEventSystem { get; set; }
        public Action<T> OnEvent { get; set; }

        public void UnRegister()
        {
            TypeEventSystem.UnRegister(OnEvent);

            TypeEventSystem = null;
            OnEvent = null;
        }
    }

    /// <summary>
    /// ע���Ĵ�����
    /// </summary>
    public class UnRegisterOnDestroyTrigger : MonoBehaviour
    {
        private HashSet<IUnRegister> mUnRegisters = new HashSet<IUnRegister>();

        public void AddUnRegister(IUnRegister unRegister)
        {
            mUnRegisters.Add(unRegister);
        }

        private void OnDestroy()
        {
            foreach (var unRegister in mUnRegisters)
            {
                unRegister.UnRegister();
            }

            mUnRegisters.Clear();
        }
    }

    /// <summary>
    /// ע����������ʹ�ü�
    /// </summary>
    public static class UnRegisterExtension
    {
        public static void UnRegisterWhenGameObjectDestroyed(this IUnRegister unRegister, GameObject gameObject)
        {
            var trigger = gameObject.GetComponent<UnRegisterOnDestroyTrigger>();

            if (!trigger)
            {
                trigger = gameObject.AddComponent<UnRegisterOnDestroyTrigger>();
            }

            trigger.AddUnRegister(unRegister);
        }
    }

    public class TypeEventSystem : ITypeEventSystem
    {
        interface IRegistrations
        {

        }

        class Registrations<T> : IRegistrations
        {
            /// <summary>
            /// ��Ϊί�б���Ϳ���һ�Զ�ע��
            /// </summary>
            public Action<T> OnEvent = obj => { };
        }

        private Dictionary<Type, IRegistrations> mEventRegistrations = new Dictionary<Type, IRegistrations>();

        public void Send<T>() where T : new()
        {
            var e = new T();
            Send<T>(e);
        }

        public void Send<T>(T e)
        {
            var type = typeof(T);
            IRegistrations eventRegistrations;

            if (mEventRegistrations.TryGetValue(type, out eventRegistrations))
            {
                (eventRegistrations as Registrations<T>)?.OnEvent.Invoke(e);
            }

        }

        public IUnRegister Register<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegistrations eventRegistrations;

            if (mEventRegistrations.TryGetValue(type, out eventRegistrations))
            {

            }
            else
            {
                eventRegistrations = new Registrations<T>();
                mEventRegistrations.Add(type, eventRegistrations);
            }

            (eventRegistrations as Registrations<T>).OnEvent += onEvent;

            return new TypeEventSystemUnRegister<T>()
            {
                OnEvent = onEvent,
                TypeEventSystem = this
            };
        }

        public void UnRegister<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegistrations eventRegistrations;

            if (mEventRegistrations.TryGetValue(type, out eventRegistrations))
            {
                (eventRegistrations as Registrations<T>).OnEvent -= onEvent;
            }
        }
    }
}