using System;
namespace FrameworkDesign
{
    public class Singleton<T> where T: class
    {
        private static T mInstance;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    var chors = typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    var chor = Array.Find(chors ,c => c.GetParameters().Length == 0);

                    if (chor == null)
                    {
                        throw new Exception("Non-public Constructor() not found in "+ typeof(T));
                    }
                    mInstance = chor.Invoke(null) as T;
                }
                return mInstance;
            }
        }
    }
}