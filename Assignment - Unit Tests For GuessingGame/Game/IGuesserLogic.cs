using Assignment___Unit_Tests_For_GuessingGame.Enums;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("GuessingGameTests")]
namespace Assignment___Unit_Tests_For_GuessingGame.Game
{
    internal interface IGuesserLogic
    {
        public GuessResults ManageGuess(int correctNumber, int guess, int tries);
    }
}