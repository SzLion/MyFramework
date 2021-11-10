using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace FrameworkDesign.Example
{
    public class Event<T> where T : Event<T>
    {
        private static Action mOnEventTrigger;
        /// <summary>
        /// ע���¼�
        /// </summary>
        /// <param name="onEvent"></param>
        public static void Register(Action onEvent)
        {
            mOnEventTrigger += onEvent;
        }
        /// <summary>
        /// ע���¼�
        /// </summary>
        /// <param name="onEvent"></param>
        public static void UnRegister(Action onEvent)
        {
            mOnEventTrigger -= onEvent;
        }
        /// <summary>
        /// �����¼�
        /// </summary>
        public static void Trigger()
        {
            mOnEventTrigger?.Invoke();
        }
    }
}
