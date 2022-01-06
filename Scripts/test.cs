using QFramework;
using UnityEngine;

namespace HTCDemo
{
    public class test : MonoBehaviour, IController
    {
        private IScoreSystem scoreSystem;

        private IScoreModel scoreModel;
        // Start is called before the first frame update
        void Awake()
        {
            scoreSystem = this.GetSystem<IScoreSystem>();
            this.RegisterEvent<OnStateChanged>(e =>
            {
                Debug.LogError("\n状态已经切换为" + e.mState.ToString() + "当前状态分数为" + e.mCurrentScore.ToString());
            });
            this.RegisterEvent<OnSubCurrentScore>(e =>
            {
                Debug.LogError("\n状态为" + e.mState.ToString() + "当前状态分数为" + e.mCurrentScore.ToString());
            });
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.SendCommand(new ChangeStateCommand(GameState.Step2, 3));
                int totalScore = this.SendQuery(new TotalScoreQuery());
                Debug.Log("已经更改为状态2" + "当前状态为" + scoreSystem.CurrentState.CurrentState.Value.ToString() + "总分为" +
                          totalScore);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
               

                this.SendCommand(new ChangeStateCommand(GameState.Step3, 3));
                int totalScore = this.SendQuery(new TotalScoreQuery());
                Debug.Log("已经更改为状态2" + "当前状态为" + scoreSystem.CurrentState.CurrentState.Value.ToString() + "总分为" +
                          totalScore);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                

                this.SendCommand(new ChangeStateCommand(GameState.Step4, 3));
                int totalScore = this.SendQuery(new TotalScoreQuery());
                Debug.Log("已经更改为状态2" + "当前状态为" + scoreSystem.CurrentState.CurrentState.Value.ToString() + "总分为" +
                          totalScore);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                

                this.SendCommand(new ChangeStateCommand(GameState.Step5, 3));
                int totalScore = this.SendQuery(new TotalScoreQuery());
                Debug.Log("已经更改为状态2" + "当前状态为" + scoreSystem.CurrentState.CurrentState.Value.ToString() + "总分为" +
                          totalScore);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                int totalScore = this.SendQuery(new TotalScoreQuery());
                Debug.Log(  "当前状态为" + scoreSystem.CurrentState.CurrentState.Value.ToString() +"当前状态分数为"+scoreSystem.CurrentState.Score.Value + "总分为" +
                          totalScore);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                var scoreSystem = this.GetSystem<IScoreSystem>();
                this.SendCommand(new CompletedCommand());
                int totalScore = this.SendQuery(new TotalScoreQuery());
                Debug.Log(  "游戏结束，"  + "总分为" +
                            totalScore);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                var scoreSystem = this.GetSystem<IScoreSystem>();

                this.SendCommand(new ReloadCommand());
                int totalScore = this.SendQuery(new TotalScoreQuery());
                Debug.Log("已经重置游戏" + "当前状态为" + scoreSystem.CurrentState.CurrentState.Value.ToString() + "总分为" +
                          totalScore);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                var scoreSystem = this.GetSystem<IScoreSystem>();

                this.SendCommand(new SubScoreCommand());
                int totalScore = this.SendQuery(new TotalScoreQuery());
                Debug.Log("当前状态分数减一" + "当前状态为" + scoreSystem.CurrentState.CurrentState.Value.ToString() + "总分为" +
                          totalScore);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return HTCDemo.Interface;
        }
    }
}