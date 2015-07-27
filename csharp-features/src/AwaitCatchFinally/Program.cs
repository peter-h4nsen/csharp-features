using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaitCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            myClass.Run().Wait();
            
            Console.Read();
        }
    }

    public class MyClass
    {
        public async Task Run()
        {
            var myClass = new MyClass();
            
            //C# 6: It's now possible to use "await" in catch and finally blocks.
            try
            {
                var s = await myClass.GetString();
            }
            catch (Exception)
            {
                await myClass.LogError();
            }
            finally
            {
                await myClass.Close();
            }

            // Previously some annoying workarounds had to be used to get similar behaviour.
            bool failed = true;

            try
            {
                var s = await myClass.GetString();
            }
            catch (Exception)
            {
                failed = true;
            }

            if (failed)
                await myClass.LogError();

            await myClass.Close();
        }

        public Task<string> GetString()
        {
            throw new Exception("BOOOM");
            return Task.FromResult("The result");
        }

        public async Task LogError()
        {
            await Task.Delay(1000);
            Console.WriteLine("Error logged");
            return;
        }

        public async Task Close()
        {
            await Task.Delay(1000);
            Console.WriteLine("MyClass closed");
            return;
        }
    }
}
