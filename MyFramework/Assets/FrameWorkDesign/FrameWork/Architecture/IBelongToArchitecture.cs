using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    /// <summary>
    /// ������޵ݹ飬ʹArchitecture��CounterModel�໥����,���ⵥ������
    /// </summary>
    public interface IBelongToArchitecture 
    {
        IArchitecture Architecture { get; set; }
    }
}