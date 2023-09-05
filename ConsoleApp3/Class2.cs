using AspectInjector.Broker;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    [Aspect(Scope.Global)]
    [Injection(typeof(LogCall))]
    public class LogCall : Attribute
    {
        [Advice(Kind.Before)] // you can have also After (async-aware), and Around(Wrap/Instead) kinds
        public void LogEnter([Argument(Source.Type)] Type type, [Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] objcts)
        {
            if(!name.Contains( ".ctor"))
            Console.WriteLine($"Calling '{type.FullName}'.'{ name} '( " +JsonConvert.SerializeObject(objcts)+" )");   //you can debug it	
        }
        [Advice(Kind.Around, Targets = Target.AnyAccess)] // you can have also After (async-aware), and Around(Wrap/Instead) kinds
        public object Trace(
       [Argument(Source.Type)] Type type,
       [Argument(Source.Name)] string name,
       [Argument(Source.Target)] Func<object[], object> methodDelegate,
       [Argument(Source.Arguments)] object[] args)
        {
            if (!name.Contains(".ctor"))
            {
                Console.WriteLine($"[{DateTime.UtcNow}] Method {type.Name}.{name} started");
            }
            var sw = Stopwatch.StartNew();
                var result = methodDelegate(args);
                sw.Stop();
            if (!type.FullName.Contains(".ctor"))
            {
                Console.WriteLine($"[{DateTime.UtcNow}] Method {type.Name}.{name} finished in {sw.ElapsedMilliseconds} ms");
            }
            return result;
           
        }
        [Advice(Kind.After)] // you can have also After (async-aware), and Around(Wrap/Instead) kinds
        public void LogOut([Argument(Source.Type)] Type type, [Argument(Source.Name)] string name, [Argument(Source.ReturnValue)] object objcts)
        {
            if (!name.Contains(".ctor"))
                Console.WriteLine($"Out '{type.FullName}.{name}'( "+JsonConvert.SerializeObject(objcts)+" )");   //you can debug it	
        }
    }
}
