using MethodTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FodySample
{
    public class Foo
    {
        [Time]
        public void Bar()
        {
            Thread.Sleep(234);
        }
        [Time]
        public async Task Bar_Async()
        {
            var length = await ExampleMethodAsync();
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXX: {0}", length);
        }

        // Thx MSDN: http://msdn.microsoft.com/en-us/library/hh156513(v=VS.110)
        public async Task<int> ExampleMethodAsync()
        {
            return (await new HttpClient().GetStringAsync("http://msdn.microsoft.com")).Length;
        }
    }

    // Interceptor.  Dunno how this works just yet, but it does :)
    public static class MethodTimeLogger
    {
        public static long lastCount;
        public static ushort numCalls;
        public static void Log(MethodBase methodBase, long milliseconds)
        {
            Console.WriteLine("RR {0}.{1} : {2}", methodBase.DeclaringType.Name, methodBase.Name, milliseconds);
            numCalls++;
            if (milliseconds > 0) // dunno why this happens either.
                lastCount = milliseconds;
        }
    }
}
