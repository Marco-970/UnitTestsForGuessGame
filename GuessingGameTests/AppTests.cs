using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameTests
{
    [TestFixture]
    public class AppTests
    {
#nullable disable
        Mock<IRoller> _roller;
        Mock<IUserInteractor> _userInteractor;
        IInputValidator _validator;
        IGuesserLogic _guesser;
        App _app;
#nullable enable
        [SetUp]
        public void Setup()
        {
            _roller = new Mock<IRoller>();
            _userInteractor = new Mock<IUserInteractor>();
            _validator = new InputValidator();
            _guesser = new GuesserLogic();

            _app = new App(_roller.Object, _userInteractor.Object, _validator, _guesser);
        }

        [Test]
        public void StartGame_ShallDisplayCorrectMessage_IfGameWonImmediately()
        {
            _roller.Setup(mock => mock.Roll()).Returns(4);
            _userInteractor.Setup(mock => mock.Read()).Returns("4");
            _app.StartGame();

            _userInteractor.Verify(x => x.Print("You won! And you had 2 try/tries left!"), Times.Once);
        }

        [Test]
        public void StartGame_ShallDisplayCorrectMessage_IfGameWonSecondTry()
        {
            _roller.Setup(mock => mock.Roll()).Returns(3);
            _userInteractor.SetupSequence(mock => mock.Read())
                .Returns("4")
                .Returns("3");
            _app.StartGame();

            _userInteractor.Verify(x => x.Print("You won! And you had 1 try/tries left!"), Times.Once);
        }

        [Test]
        public void StartGame_ShallDisplayCorrectMessage_IfGameWonThirdTry()
        {
            _roller.Setup(mock => mock.Roll()).Returns(3);
            _userInteractor.SetupSequence(mock => mock.Read())
                .Returns("4")
                .Returns("1")
                .Returns("3");
            _app.StartGame();

            _userInteractor.Verify(x => x.Print("You won! And you had 0 try/tries left!"), Times.Once);
        }

        [Test]
        public void StartGame_ShallDisplayCorrectMessage_IfAnswerIsWrong()
        {
            _roller.Setup(mock => mock.Roll()).Returns(3);
            _userInteractor.SetupSequence(mock => mock.Read())
                .Returns("4");
            _app.StartGame();

            _userInteractor.Verify(x => x.Print("Wrong answer!"), Times.AtLeastOnce);
        }

        [Test]
        public void StartGame_ShallDisplayCorrectMessage_IfGameOver()
        {
            _roller.Setup(mock => mock.Roll()).Returns(3);
            _userInteractor.SetupSequence(mock => mock.Read())
                .Returns("4")
                .Returns("6")
                .Returns("1");
            _app.StartGame();

            _userInteractor.Verify(x => x.Print("You lost. The correct number was 3"), Times.Once);
        }
    }
}
