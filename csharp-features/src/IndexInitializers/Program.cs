using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# 6: With "index initializers" values can be set on indexers in the same style as 
            // when using "object initializers" and "collection initializers" to initialize objects.
            var myClass = new MyClass
            {
                [2] = "Index2",
                [4] = "Index4",
                [6] = "Index6",
            };

            var valuesNew = new Dictionary<int, string>
            {
                [1] = "Val1",
                [2] = "Val2",
                [3] = "Val3",
            };

            // Previously the syntax to initialize dictionaries was not as elegant.
            var valuesOld = new Dictionary<int, string>
            {
                { 1, "Val1" },
                { 2, "Val2" },
                { 3, "Val3" },
            };

            Console.Read();
        }

        public class MyClass
        {
            public string this[int key]
            {
                get { return ""; }
                set {  }
            }
        }
    }
}
