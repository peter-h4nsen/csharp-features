using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullConditional
{
    class Program
    {
        public static event PropertyChangedEventHandler PropertyChanged;

        static void Main(string[] args)
        {

            Child child = new Child();

            // Previously null checks were needed before accessing a parent property.
            string grandParentNameOld = "No name found";

            if (child.Parent != null)
                if (child.Parent.GrandParent != null)
                    grandParentNameOld = child.Parent.GrandParent.Name;

            // C# 6: If any property is null, a null result is returned immediately.
            // Can be conveniently used with the null-coalescing operator.
            string grandParentNameNew = child.Parent?.GrandParent?.Name ?? "No name found";

            Console.WriteLine(grandParentNameOld);
            Console.WriteLine(grandParentNameNew);

            // C# 6: Also works with indexers.
            int[] arr = null;
            int foundOld = arr != null ? arr[1337] : 0;
            int foundNew = arr?[1337] ?? 0;

            // Can't use Null-conditional operator to call a delegate directly.
            // But can be used by calling the Invoke method.
            Func<string, string> func = null;
            string result = func?.Invoke("Not invoked");
            //string result = func?(); // Syntax not supported

            // The Null-conditional operator is nice to use when raising events.
            // The call is thread-safe, since the reference is held in a temporary variable.
            PropertyChanged?.Invoke(null, null);

            Console.Read();
        }

        public class Child
        {
            public Parent Parent { get; set; }
        }

        public class Parent
        {
            public GrandParent GrandParent { get; set; }
        }

        public class GrandParent
        {
            public string Name { get; } = "MyName";
        }
    }
}
