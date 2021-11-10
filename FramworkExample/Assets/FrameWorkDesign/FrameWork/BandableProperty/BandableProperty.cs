using System;
namespace FrameworkDesign
{
    public class BandableProperty<T> where T : IEquatable<T>
    {
        private T mValue;
        public T Value {
            get => mValue;

            set {
                if (!mValue.Equals(value))
                {
                    mValue = value;
                    OnValueChanged?.Invoke(value);
                }
            }
        }
        public Action<T> OnValueChanged;
    }
}