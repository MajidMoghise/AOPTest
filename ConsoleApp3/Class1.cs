using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp3
{
    [LogCall]
    public class Bar
	{
       // [LogCall]
        public Bar() { }

       // [LogCall]
        public int Calculate(Prop p) { var r=Div(p.X, p.Y);
            var rr = new Bar2();
            var rrr=rr.Calculate(p);
            return p.X + p.Y; }
        private int Div(int x, int y) { return x - y; }
	}
    public class Bar2
    {
        public Bar2() { }

        // [LogCall]
        public int Calculate(Prop p) {  return p.X * p.Y; }
        
    }
   public class Prop
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    [AttributeUsage(AttributeTargets.All)]
    public class CallTracingAttribute : Attribute
	{
		public CallTracingAttribute(string s)
		{
			Console.WriteLine(s);
		}
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }
        public override bool Match(object? obj)
        {
            return base.Match(obj);
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public void Test()
        {
            Console.WriteLine("Test");
        }
    }
	
}
