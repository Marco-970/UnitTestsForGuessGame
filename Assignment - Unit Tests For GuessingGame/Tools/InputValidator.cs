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
    internal class InputValidator : IInputValidator
    {
        public int Validate(string input)
        {
            bool isValid = int.TryParse(input, out int result) == true && (result > 0 && result <= 6);
            return isValid ? result : 0;
        }
    }
}
