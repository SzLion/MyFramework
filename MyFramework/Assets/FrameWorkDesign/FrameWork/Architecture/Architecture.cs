using System;
using System.Collections.Generic;
namespace FrameworkDesign
{
    public interface IArchitecture
    {
        void RegisterModel<T>(T instance) where T : IModel;
        void RegisterUtility<T>(T instance);
        T GetUtility<T>() where T : class;
    }
    public abstract class Architecture<T>:IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// 是否初始化完成
        /// </summary>
        private bool mInited = false;
        /// <summary>
        /// 用于初始化的models的缓存
        /// </summary>
        private List<IModel> mModels = new List<IModel>();
        #region 类似单例模式，但是仅在内部可访问

        public static Action<T> OnRegisterPatch = architecture => { };

        private static T mArchitecture = null;

        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                OnRegisterPatch?.Invoke(mArchitecture);

                foreach (var architectureModel in mArchitecture .mModels)
                {
                    architectureModel.init();
                }
                mArchitecture.mModels.Clear();
                mArchitecture.mInited = true;
            }
        }
        #endregion
        private static IOCContainer mContainer = new IOCContainer();
        protected abstract void Init();

        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mContainer.Register<T>(instance);
        }
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mContainer.Get<T>();
        }
        public void RegisterModel<T>(T instance) where T : IModel
        {
            instance.Architecture = this;
            mContainer.Register<T>(instance);
            if (mInited)
            {
                instance.init();
            }
            else
            {
                mModels.Add(instance);
            }
        }

        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }

        public void RegisterUtility<T>(T instance)
        {
            mContainer.Register<T>(instance);
        }
        /// <summary>
        /// 销毁Architecture
        /// </summary>
        public static void DestoryArchitecture()
        {
            mArchitecture = null;
        }
    }
}