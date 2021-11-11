using UnityEngine;
namespace FrameworkDesign.Example
{
    public class CanDoEverything
    {
        public void DoSomething1()
        {
            Debug.Log("DoSomething1");
        }
        public void DoSomething2()
        {
            Debug.Log("DoSomething2");
        }
        public void DoSomething3()
        {
            Debug.Log("DoSomething3");
        }

    }
    public interface IHaveEverything
    {
        CanDoEverything CanDoEverything { get; } 
    }

    public interface ICanDoSomething1:IHaveEverything
    {

    }
    public static class IcanDoSomething1Extensions
    {
        public static void DoSomething1(this ICanDoSomething1 self)
        {
            self.CanDoEverything.DoSomething1();            
        }
    }
    public interface ICanDoSomething2 : IHaveEverything
    {

    }
    public static class ICanDoSomething2Extensions
    {
        public static void DoSomething2(this ICanDoSomething2 self)
        {
            self.CanDoEverything.DoSomething2();
        }
    }
    public interface ICanDoSomething3 : IHaveEverything
    {

    }
    public static class ICanDoSomething3Extensions
    {
        public static void DoSomething3(this ICanDoSomething3 self)
        {
            self.CanDoEverything.DoSomething3();
        }
    }

    public class InterfaceRuleExample : MonoBehaviour
    {
        public class OnlyCanDo1 : ICanDoSomething1
        {
            CanDoEverything IHaveEverything.CanDoEverything { get; } = new CanDoEverything();
        }

        public class OnlyCanDo23 : ICanDoSomething2, ICanDoSomething3
        {
            CanDoEverything IHaveEverything.CanDoEverything { get; } = new CanDoEverything();
        }

        void Start()
        {
            OnlyCanDo1 onlyCanDo1 = new OnlyCanDo1();
            //可以调用DoSomething1 不可以调用23，会报编译错误
            onlyCanDo1.DoSomething1();

            var onlyCanDo23 = new OnlyCanDo23();
            //只可以调用23
            onlyCanDo23.DoSomething2();
            onlyCanDo23.DoSomething3();
        }

    }
}