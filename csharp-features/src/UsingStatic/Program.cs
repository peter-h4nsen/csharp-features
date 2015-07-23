using System;

// C# 6: Can import all static members of a type.
using static System.Console;
using static UsingStatic.MyClass;
using static UsingStatic.MyEnum;

// C#6: Extension methods won't be available in the global space like normal static methods,
// but "using static" can be used to narrow down the available extension methods.
// Normally all extension methods in a namespace will become available. 
// In this case only the ones in class "ExtensionMethods2" will be available.
using static ExtensionMethods.ExtensionMethods2;

namespace UsingStatic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Previously the static method had to be called on its type.
            Console.WriteLine("My old message");
            MyClass.MyStaticMethod("My old message");

            // C# 6: No need to define the type, because it has been imported in a "using static" statement.
            WriteLine("My new message");
            MyStaticMethod("My new message");

            // C# 6: Can also directly reference the values of an enum.
            var enumValOld = MyEnum.MyEnumValue3;
            var enumValNew = MyEnumValue2;
            WriteLine(enumValOld);
            WriteLine(enumValNew);

            // C#6: Only extension methods in class "ExtensionMethods2" can be used, 
            // because the entire "ExtensionMethods" namespace has not been imported.
            string tester = "";
            tester.Test2();
            //tester.Test1(); // Can't find methods.

            ReadLine();
        }
    }

    public class MyClass
    {
        public static void MyStaticMethod(string message)
        {
            WriteLine(message);
        }
    }

    public enum MyEnum
    {
        MyEnumValue1,
        MyEnumValue2,
        MyEnumValue3,
        MyEnumValue4,
    }
}

namespace ExtensionMethods
{
    public static class ExtensionMethods1
    {
        public static void Test1(this string s)
        {
        }
    }

    public static class ExtensionMethods2
    {
        public static void Test2(this string s)
        {
        }
    }
}
