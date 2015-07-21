using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProperties
{
    class Program
    {
        public class MyClass
        {
            public MyClass()
            {
                // In versions prior to C# 6 properties would be set in the constructor.
                //Id = 1;
                //Name = "MyName";
                //Age = 10;
                //Weight = 50.13m;

                // Can assign getter-only property in constructor.
                Message = "My message";
            }

            // C# 6: Initializers for auto-properties.
            public int Id { get; set; } = 2;
            public string Name { get; set; } = "My New Name";
            public int Age { get; set; } = 20;
            public decimal Weight { get; set; } = 13.37m;

            // C# 6: Getter-only auto-properties.
            // Can be assigned through an initializer on the property (IsNice),
            // or in the constructor of the declaring type (Message).
            // Previously you would have a readonly field and a readonly property returning the field,
            // but now you can create immutable types using auto-properties instead.
            public bool IsNice { get; } = true;
            public string Message { get; }

            public override string ToString()
            {
                return $"Id: {Id}\r\nName: {Name}\r\nAge: {Age}\r\nWeight: {Weight}\r\nIsNice: {IsNice}\r\nMessage: {Message}";
            }
        }

        static void Main(string[] args)
        {
            var myClassOld = new MyClass
            {
                Id = 1,
                Name = "MyName",
                Age = 10,
                Weight = 50.13m
            };

            var myClassNew = new MyClass();

            Console.WriteLine(myClassOld);
            Console.WriteLine("");
            Console.WriteLine(myClassNew);

            Console.ReadLine();
        }
    }
}
