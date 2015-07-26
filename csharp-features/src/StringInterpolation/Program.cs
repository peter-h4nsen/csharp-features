using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new
            {
                FirstName = "MyFirstName",
                LastName = "MyLastName",
                Age = 34
            };

            // Previously placeholders has to be supplies as arguments to string.format meothod.
            string messageOld = string.Format("Hi, my name is {0} {1}. I am {2} years old.", person.FirstName, person.LastName, person.Age);
            Console.WriteLine(messageOld);

            // C# 6: Expressions can be put directly into the string.
            string messageNew = $"Hi, my name is {person.FirstName} {person.LastName}. I am {person.Age} year{(person.Age > 1 ? "s" : "")} old.";
            Console.WriteLine(messageNew);

            Console.Read();
        }
    }
}
