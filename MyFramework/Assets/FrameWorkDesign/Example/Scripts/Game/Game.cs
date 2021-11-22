using UnityEngine;
namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour, IController
    {
        // Start is called before the first frame update
        void Start()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);
        }




        private void OnGameStart(GameStartEvent e)
        {
            transform.Find("Enemys").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}
