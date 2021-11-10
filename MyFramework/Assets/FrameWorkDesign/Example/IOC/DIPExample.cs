using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
    #endif
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class DIPExample : MonoBehaviour
    {
        /// <summary>
        /// 设计接口
        /// </summary>
        public interface IStorage
        {
            void SaveString(string key,string value);
            string LoadString(string key,string defaultValue = "");
        }
        public class PlayerPrefsStorage : IStorage
        {
            public string LoadString(string key, string defaultValue = "")
            {
                return PlayerPrefs.GetString(key,defaultValue);
            }

            public void SaveString(string key, string value)
            {
                PlayerPrefs.SetString(key ,value);
            }
        }
        public class EditorPrefsStorage : IStorage
        {
            public string LoadString(string key, string defaultValue = "")
            {
                return EditorPrefs.GetString(key ,defaultValue);
            }

            public void SaveString(string key, string value)
            {
                EditorPrefs.SetString(key ,value);
            }
        }
        private void Start()
        {
            var container = new IOCContainer();
            container.Register<IStorage>(new PlayerPrefsStorage());
            var storage = container.Get<IStorage>();
            storage.SaveString("name","运行时存储");
            Debug.Log(storage .LoadString("name"));
            //切换实现
            container.Register<IStorage>(new EditorPrefsStorage());
            storage = container.Get<IStorage>();
            Debug.Log(storage.LoadString("name"));
        }
    }
}