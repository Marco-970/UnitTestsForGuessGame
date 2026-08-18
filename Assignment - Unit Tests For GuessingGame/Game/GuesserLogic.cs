using Assignment___Unit_Tests_For_GuessingGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("GuessingGameTests")]
namespace Assignment___Unit_Tests_For_GuessingGame.Game
{
    internal class GuesserLogic : IGuesserLogic
    {
        public GuessResults ManageGuess(int correctNumber, int guess, int tries)
        {
            if (tries <= 0)
            {
                return GuessResults.GameOver;
            }
            
            if (guess == correctNumber)
            {
                return GuessResults.Correct;
            }

            return GuessResults.Incorrect;

        }
    }
}
