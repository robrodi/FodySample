using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FodySample.Tests
{
    public class BasicTests
    {
        [Fact]
        public void Bar()
        {
            new Foo().Bar();
        }
    }
}
