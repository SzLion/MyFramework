using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public class IOCContainer
    {
        public Dictionary<Type, object> mInstance = new Dictionary<Type, object> ();

        /// <summary>
        /// ×¢²á
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public void Register<T>(T instance)
        {
            var key = typeof(T);
            if (mInstance.ContainsKey(key))
            {
                mInstance[key] = instance;
            }
            else
            {
                mInstance.Add(key ,instance);
            }
        }
        /// <summary>
        /// »ñÈ¡
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : class
        {
            var key = typeof(T);
            object retobj;
            if (mInstance .TryGetValue(key,out retobj))
            {
                return retobj as T;
            }
            return null;
        }
    }
}