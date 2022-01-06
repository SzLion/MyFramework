using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace HTCDemo
{


    public class HTCDemo : Architecture<HTCDemo>
    {
        protected override void Init()
        {
            this.RegisterSystem<IScoreSystem>(new ScoreSystem());
            this.RegisterModel<IScoreModel>(new ScoreModel());
        }
    }
}
