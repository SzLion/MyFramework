using UnityEngine;
namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour, IController
    {
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void OnMouseDown()
        {
            Destroy(gameObject);
            this.SendCommand<KillEnemyCommand>();
        }
    }
}
