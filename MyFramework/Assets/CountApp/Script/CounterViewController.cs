using FrameworkDesign.Example;
using FrameworkDesign;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public interface ICounterModel:IModel
    {
        BandableProperty<int> Count { get; }
    }
    public class CounterViewController : MonoBehaviour,IController 
    {
       
        private ICounterModel mCounterModel;

        

        // Start is called before the first frame update
        void Start()
        {
        
            mCounterModel = Architecture.GetModel<ICounterModel>();
            mCounterModel.Count.OnValueChanged += OnCountChanged;
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                new AddCountCommand().Execute();

            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                new SubCountCommand().Execute();

            });
            OnCountChanged(mCounterModel.Count.Value);
        }

        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
        }
        private void OnDestroy()
        {
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
        }
        public IArchitecture Architecture { get; set; } = CounterApp.Interface;
    }
    public class CounterModel : ICounterModel
    {       
        public void init()
        {
            var storage = Architecture.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }
        public BandableProperty<int> Count { get; } = new BandableProperty<int>() { Value = 0 };
        public IArchitecture Architecture { get ; set ; }

    }
}

