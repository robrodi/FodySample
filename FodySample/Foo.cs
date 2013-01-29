using MethodTimer;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Thread.Sleep(1234);
        }
    }
}
