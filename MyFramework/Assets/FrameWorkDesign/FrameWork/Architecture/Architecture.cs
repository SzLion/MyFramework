using System;
using System.Collections.Generic;
namespace FrameworkDesign
{
    public interface IArchitecture
    {
        /// <summary>
        /// 注册系统
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        void RegisterSystem<T>(T instance) where T : ISystem;
        /// <summary>
        /// 注册Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        void RegisterModel<T>(T instance) where T : IModel;
        /// <summary>
        /// 注册Utility
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        void RegisterUtility<T>(T instance);
        /// <summary>
        /// 获取Utility
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetUtility<T>() where T : class;
        /// <summary>
        /// 获取Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetModel<T>() where T : class, IModel;
    }
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// 是否初始化完成
        /// </summary>
        private bool mInited = false;


        /// <summary>
        /// 用于初始化的models的缓存
        /// </summary>
        private List<IModel> mModels = new List<IModel>();
        private List<ISystem> mSystems = new List<ISystem>();
        #region 类似单例模式，但是仅在内部可访问

        public static Action<T> OnRegisterPatch = architecture => { };

        private static T mArchitecture;
        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureArchitecture();
                }
                return mArchitecture;
            }
        }

        public void RegisterModel<T>(T instance) where T : IModel
        {
            instance.SetArchitecture(this);
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

        public void RegisterSystem<T>(T instance) where T : ISystem
        {
            instance.SetArchitecture(this);
            mContainer.Register<T>(instance);
            if (mInited)
            {
                instance.init();
            }
            else
            {
                mSystems.Add(instance);
            }
        }

        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                OnRegisterPatch?.Invoke(mArchitecture);

                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.init();
                }
                mArchitecture.mModels.Clear();
                foreach (var architectureSystem in mArchitecture.mSystems)
                {
                    architectureSystem.init();
                }
                mArchitecture.mSystems.Clear();
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

        public T GetModel<T>() where T : class, IModel
        {
            return mContainer.Get<T>();
        }
    }
}