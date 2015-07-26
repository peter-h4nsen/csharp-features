using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# 6: Can define a condition that needs to be true for an exception to be catched.
            // Previously you could check the condition as the first thing in the catch-block,
            // but that would add a extra step in the stack-trace.
            try
            {
                throw new ArgumentException("error");
            }
            catch (ArgumentException argEx) when (argEx.Message == "error")
            {
                if (argEx.Message != "error")
                    throw;

                Console.WriteLine("Exception catched. Passed filter.");
            }

            // C# 6: Exception filters can be abused to inspect an exception without actually catching it.
            // In this example the exception is logged, but since the filter returns false, it will not reach the catch-block.
            try
            {
                throw new Exception("BOOOOM!!");
            }
            catch (Exception ex) when (LogException(ex)) {}

            Console.Read();
        }

        private static bool LogException(Exception ex)
        {
            Console.WriteLine("Exception logged..!");
            return false;
        }
    }
}
