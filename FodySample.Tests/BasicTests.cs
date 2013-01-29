using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace FodySample.Tests
{
    public class BasicTests
    {
        [Fact]
        public void Bar()
        {
            new Foo().Bar();
        }

        [Fact]
        public void Bar_async()
        {
            Stopwatch s = Stopwatch.StartNew();
            var foo = new Foo();
            var task = foo.Bar_Async();
            task.Wait();

            MethodTimeLogger.numCalls.Should().Be(1, "there was one call to the method, this may mean the state machine is logging when we wait");

            ///s.ElapsedMilliseconds
            long min = ((long)(s.ElapsedMilliseconds * .8));
            long max = ((long)(s.ElapsedMilliseconds * 1.2));
            MethodTimeLogger.lastCount.Should().BeInRange(min, max, "the timer should reflect the actual time, not when the async promise is returned");
        }
    }
}
