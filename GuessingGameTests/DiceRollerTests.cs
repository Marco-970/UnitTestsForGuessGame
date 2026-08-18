global using NUnit.Framework;
global using Assignment___Unit_Tests_For_GuessingGame.Game;
global using Assignment___Unit_Tests_For_GuessingGame.Tools;
global using Assignment___Unit_Tests_For_GuessingGame.Enums;

namespace GuessingGameTests
{
    [TestFixture]
    public class DiceRollerTests
    {
        [Test]
        public void Roll_ShallReturnValidNumber()
        {
            var _diceRoller = new DiceRoller(new Random());

            var result = _diceRoller.Roll();
            IEnumerable<int> expected = new int[] {1,2,3,4,5,6};
            Assert.That(expected.Any(number => number == result));
        }
    }
}
