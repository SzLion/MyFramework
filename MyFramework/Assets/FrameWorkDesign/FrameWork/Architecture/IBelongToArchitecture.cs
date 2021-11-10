using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    /// <summary>
    /// 解决无限递归，使Architecture与CounterModel相互持有,避免单例调用
    /// </summary>
    public interface IBelongToArchitecture 
    {
        IArchitecture Architecture { get; set; }
    }
}