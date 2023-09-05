

using AOP.Core;
using ConsoleApp3;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
		var b = new Bar();
		//object[] attrs = CallTracingAttribute.GetCustomAttributes(b.GetType());
		////var attrsM = b.GetType().GetMethod("Calculate").CustomAttributes;
		//
		//var types = b.GetType().CustomAttributes.Where(t => t.GetType()==(typeof(CallTracingAttribute)));
		//
        //foreach (var item in attrs)
        //{
		//	((CallTracingAttribute)item).IsDefaultAttribute();
		//	 //item.GetType().GetMethod("Test");
		//	//item.Constructor.Invoke(null);
		//}
		b.Calculate(new Prop { Y = 5, X = 6 });
		Console.ReadLine();
	}
}

interface IService
{
	int DoWork(int i,int j);
	int dd(int i, int j);
}

class Service : IService
{
	public int DoWork(int i,int j)
	{
		var f = dd(i, j);
		return i + j;
	}
	public int dd(int i,int j)
    {
		return (i * j) - j;
    }
}

/// <summary>
/// Your aspect
/// </summary>
/// <typeparam name="T"></typeparam>
public class MyAspect<T> : Aspect<T>, IBeforeAdvice, IAroundAdvice, IAfterAdvice, IAfterThrowAdvice where T : class
{
	public MyAspect()
	{

	}

	public void OnBefore(AOP.Core.ExecutionContext context)
	{
		//code executed before
	}

	public AroundExecutionResult OnAround(AOP.Core.ExecutionContext context)
	{
		//code executed around

		return new AroundExecutionResult
		{
			Proceed = true,
			OverwrittenResult = null
		};
	}

	public void OnAfter(AOP.Core.ExecutionContext context, object result)
	{
		//code executed after
	}

	public void OnThrow(AOP.Core.ExecutionContext context, Exception exception)
	{
		//code executed on exception throw
	}
}

//IService and Service are your object/service class to observe/control


