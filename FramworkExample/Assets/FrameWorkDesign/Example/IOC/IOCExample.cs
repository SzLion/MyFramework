using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example {
    public class IOCExample : MonoBehaviour
    {
        void Start()
        {
            var container = new IOCContainer();
            container.Register<IBluetoothmanager>(new aBluetoothmanager());
            var bluetoothmanager = container.Get<IBluetoothmanager>();
            bluetoothmanager.Connect();
        }


    }
    public interface IBluetoothmanager
    {
         void Connect();
    }
    public class Bluetoothmanager: IBluetoothmanager
    {
        public void Connect()
        {
            Debug.Log("test");
        }
    }
    public class aBluetoothmanager : IBluetoothmanager
    {
        public void Connect()
        {
            Debug.Log("222");
        }
    }
}