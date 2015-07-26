using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameOf
{
    class Program
    {
        static void Main(string[] args)
        {
            string myStringOld = string.Empty;
            Console.WriteLine("The variable name is: myStringOld");

            // C# 6: Using the nameof-expression can prevent putting names of variables, arguments, properties etc. into string literals.
            // This helps when refactoring the name and makes sure there are no typos in the string etc.
            string myStringNew = string.Empty;
            Console.WriteLine($"The variable name is: {nameof(myStringNew)}");

            Console.Read();
        }

        public class MyClass : INotifyPropertyChanged
        {
            public MyClass(string value)
            {
                // With a string literal we must remember to change the string when the parameter name changes.
                if (value == null)
                    throw new ArgumentNullException("value");

                //C# 6: With nameof we will get a compiler error as soon as the parameter name changes.
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
            }

            private string _myProperty;
            public string MyProperty
            {
                get { return _myProperty; }
                set
                {
                    _myProperty = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyProperty"));

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyProperty)));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
