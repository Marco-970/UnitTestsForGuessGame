using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("GuessingGameTests")]
namespace Assignment___Unit_Tests_For_GuessingGame.Tools
{
    internal class ConsoleUserInteractor : IUserInteractor
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public string Read()
        {
            return Console.ReadLine() ?? "null";
        }
        public void Quit()
        {
            Console.ReadKey();
        }
    }
}
