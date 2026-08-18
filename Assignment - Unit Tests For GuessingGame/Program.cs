using Assignment___Unit_Tests_For_GuessingGame.Game;
using Assignment___Unit_Tests_For_GuessingGame.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment___Unit_Tests_For_GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUserInteractor _userInteractor = new();
            string _userInput;
            do
            {
                App game = new(new DiceRoller(new Random()), _userInteractor, new InputValidator(), new GuesserLogic());

                game.StartGame();

                _userInteractor.Print("Do you want to play again? Y/N");
                _userInput = _userInteractor.Read();
            } while (_userInput == "Y" || _userInput == "y");
            _userInteractor.Print("Nice playing with you, goodbye!");
            _userInteractor.Quit();
        }
    }
}
