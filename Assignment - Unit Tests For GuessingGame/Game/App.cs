using Assignment___Unit_Tests_For_GuessingGame.Enums;
using Assignment___Unit_Tests_For_GuessingGame.Tools;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("GuessingGameTests")]
namespace Assignment___Unit_Tests_For_GuessingGame.Game
{
    internal class App
    {
        private readonly IRoller _diceRoller;
        private readonly IUserInteractor _userInteractor;
        private readonly IInputValidator _inputValidator;
        private readonly IGuesserLogic _guesserLogic;
        const int InitialTries = 3;

        public App(IRoller diceRoller, IUserInteractor userInteractor, IInputValidator inputValidator, IGuesserLogic guesserLogic)
        {
            _diceRoller = diceRoller;
            _userInteractor = userInteractor;
            _inputValidator = inputValidator;
            _guesserLogic = guesserLogic;
        }
        public void StartGame()
        {
            int _triesLeft = InitialTries;
            int _dieNumber = _diceRoller.Roll();
            int _userGuess = 0;
            bool _isValid = false;
            GuessResults _gameState = GuessResults.Incorrect;

            _userInteractor.Print($"Die rolled. Guess what number it shows in {InitialTries} tries.");


            do
            {
                if (_triesLeft > 0)
                {
                    _userInteractor.Print("Enter a number:");
                    _userGuess = _inputValidator.Validate(_userInteractor.Read());
                }

                _gameState = _guesserLogic.ManageGuess(_dieNumber, _userGuess, _triesLeft);
                _triesLeft--;

                switch (_gameState)
                {
                    case GuessResults.Incorrect:
                        _userInteractor.Print("Wrong answer!");
                        break;
                    case GuessResults.Correct:
                        _userInteractor.Print($"You won! And you had {_triesLeft} try/tries left!");
                        return;
                    case GuessResults.GameOver:
                        _userInteractor.Print($"You lost. The correct number was {_dieNumber}");
                        return;
                }
            } while (_gameState != GuessResults.GameOver);
        }
    }
}
