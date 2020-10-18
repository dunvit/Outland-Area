using System.Threading.Tasks;

namespace Examples.AsyncInitialization
{
    class Demo
    {
        public static async Task Main(string[] args)
        {
            var foo = await Foo.CreateAsync();

            //var foo2 = new Foo();
        }
    }
}
