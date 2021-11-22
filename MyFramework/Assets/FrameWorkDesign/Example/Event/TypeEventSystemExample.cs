using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class TypeEventSystemExample : MonoBehaviour
    {
        public struct EventA { };

        public struct EventB
        {
            public int ParamB;
        }
        public interface IEventGroup { }

        public struct EventC : IEventGroup { }

        public struct EventD : IEventGroup { }

        private ITypeEventSystem mTypeEventSystem = null;

        // Start is called before the first frame update
        void Start()
        {
            mTypeEventSystem = new TypeEventSystem();
            mTypeEventSystem.Register<EventA>(eA =>
            {
                Debug.Log("EventA");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            mTypeEventSystem.Register<EventB>(OnEventB);
            mTypeEventSystem.Register<IEventGroup>(group =>
            {
                Debug.Log(group.GetType());
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnEventB(EventB e)
        {
            Debug.Log("EventB" + e.ParamB);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input .GetMouseButtonDown(0))
            {
                mTypeEventSystem.Send<EventA>();
            }
            if (Input .GetMouseButtonDown(1))
            {
                mTypeEventSystem.Send(new EventB()
                {
                    ParamB = 123
                });
            }
            if (Input .GetKeyDown(KeyCode.Space))
            {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }
        private void OnDestroy()
        {
            mTypeEventSystem.UnRegister<EventB>(OnEventB);
            mTypeEventSystem = null;
        }
    }
}