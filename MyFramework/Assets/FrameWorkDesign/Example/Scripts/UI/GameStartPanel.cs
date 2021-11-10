using UnityEngine;
using UnityEngine.UI;
namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.Find("BtnGameStart").GetComponent<Button>().onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                new GameStartCommand().Execute();
            });
        }
    }
}