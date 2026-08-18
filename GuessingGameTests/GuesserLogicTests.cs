using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameTests
{
    [TestFixture]
    public class GuesserLogicTests
    {
        private IGuesserLogic _guesserLogic;

        [SetUp]
        public void Setup()
        {
            _guesserLogic = new GuesserLogic();
        }

        [TestCase(1, 1, 2, GuessResults.Correct)]
        [TestCase(3, 3, 3, GuessResults.Correct)]
        [TestCase(4, 4, 1, GuessResults.Correct)]
        public void ManageGuess_ShallReturnCorrect_WithRightAnswer_AndAvailableTries(int correct, int guess, int tries, GuessResults expected)
        {
            var result = _guesserLogic.ManageGuess(correct, guess, tries);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 4, 3, GuessResults.Incorrect)]
        [TestCase(6, 5, 1, GuessResults.Incorrect)]
        [TestCase(2, 1, 2, GuessResults.Incorrect)]
        public void ManageGuess_ShallReturnIncorrect_WithWrongAnswer_AndAvailableTries(int correct, int guess, int tries, GuessResults expected)
        {
            var result = _guesserLogic.ManageGuess(correct, guess, tries);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 4, 0, GuessResults.GameOver)]
        [TestCase(1, 1, -1, GuessResults.GameOver)]
        [TestCase(5, 3, 0, GuessResults.GameOver)]
        [TestCase(3, 3, -2, GuessResults.GameOver)]
        public void ManageGuess_ShallReturnGameOver_WithNoTriesAvailable(int correct, int guess, int tries, GuessResults expected)
        {
            var result = _guesserLogic.ManageGuess(correct, guess, tries);
            Assert.AreEqual(expected, result);
        }
    }
}
