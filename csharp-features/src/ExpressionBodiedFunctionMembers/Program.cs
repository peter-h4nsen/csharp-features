using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedFunctionMembers
{
    class Program
    {

        public class MyClass
        {
            public string Name { get; } = "My name";
            public int Age { get; private set; } = 50;

            // Previous versions. Block body with a single return statement.
            public string MakeDescription()
            {
                return string.Format("{0} ({1} years old)", Name, Age);
            }

            // C# 6: Methods with expression bodies, instead of a block body with a single statement.
            public string MakeDescriptionNew() => string.Format("New: {0} ({1} years old)", Name, Age);
            public void IncreaseAge(int years) => Age += years;
            public void Print() => Console.WriteLine(MakeDescriptionNew());

            // C# 6: Property with expression body. Will be a readonly property.
            public string DescriptionProperty => string.Format("New: {0} ({1} years old)", Name, Age);

            // C# 6: Indexer with expression body.
            public int this[int id] => 1336 + 1;
        }

        static void Main(string[] args)
        {
            var myClass = new MyClass();

            var description = myClass.MakeDescription();

            myClass.IncreaseAge(5);

            Console.WriteLine(description);
            Console.WriteLine("");
            myClass.Print();
            Console.WriteLine("");
            Console.WriteLine(myClass.DescriptionProperty);
            Console.WriteLine("");
            Console.WriteLine(myClass[1]);

            Console.Read();
        }
    }
}
