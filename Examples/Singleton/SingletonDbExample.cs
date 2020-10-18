using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Singleton
{
    public class SingletonDbExample
    {
        private static readonly Lazy<SingletonDbExample> instance = new Lazy<SingletonDbExample>(()=> new SingletonDbExample());

        public static SingletonDbExample Instance => instance.Value;

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
