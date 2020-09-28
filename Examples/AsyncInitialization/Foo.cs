using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.AsyncInitialization
{
    public class Foo
    {
        private Foo()
        {

        }

        private async Task<Foo> AsyncInitialization()
        {
            await Task.Delay(1000);

            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var foo = new Foo();

            return foo.AsyncInitialization();
        }
    }
}
