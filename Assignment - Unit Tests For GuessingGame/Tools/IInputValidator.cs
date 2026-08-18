using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("GuessingGameTests")]
namespace Assignment___Unit_Tests_For_GuessingGame.Tools
{
    internal interface IInputValidator
    {
        public int Validate(string input);
    }
}