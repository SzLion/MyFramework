using UnityEngine;
namespace FrameworkDesign.Example
{
    public class UI : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GamePassEvent.Register(OnGamePass);
        }

        private void OnGamePass()
        {
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }
        private void OnDestroy()
        {
            GamePassEvent.UnRegister(OnGamePass);
        }
    }
}
