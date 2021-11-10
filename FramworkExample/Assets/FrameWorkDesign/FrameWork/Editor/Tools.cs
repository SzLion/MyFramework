using UnityEngine;
using UnityEditor;
namespace FrameworkDesign.Example
{
    public class Tools
    {
        [MenuItem("JSTools/Editor/Debug Transform Property %#d")]
        static void DebugProperty()
        {
            var selected = Selection.activeTransform;

            if (selected != null)
            {
                Debug.Log(selected.name);
                Debug.Log("W " + selected.position + selected.rotation + selected.eulerAngles);
                Debug.Log("L " + selected.localPosition + selected.localRotation + selected.localEulerAngles);
            }
        }

        [MenuItem("JSTools/Editor/Reset Transform %#r")]
        static void ResetProperty()
        {
            var selected = Selection.activeTransform;

            if (selected != null)
            {
                selected.rotation = Quaternion.identity;
                selected.position = Vector3.zero;
                DebugProperty();
            }
        }
    }
}