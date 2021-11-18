using FrameworkDesign.Example;
using FrameworkDesign;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public interface ICounterModel : IModel
    {
        BandableProperty<int> Count { get; }
    }
    public class CounterViewController : MonoBehaviour, IController
    {

        private ICounterModel mCounterModel;



        // Start is called before the first frame update
        void Start()
        {
            mCounterModel = this.GetModel<ICounterModel>();
            mCounterModel.Count.OnValueChanged += OnCountChanged;
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.SendCommand<AddCountCommand>();

            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.SendCommand<SubCountCommand>();

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

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return CounterApp.Interface;
        }


    }
    public class CounterModel : AbstractModel, ICounterModel
    {
        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }
        public BandableProperty<int> Count { get; } = new BandableProperty<int>() { Value = 0 };


    }
}

