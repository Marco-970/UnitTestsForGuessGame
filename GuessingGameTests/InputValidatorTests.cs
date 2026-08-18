using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameTests
{
    [TestFixture]
    public class InputValidatorTests
    {
        private IInputValidator _inputValidator;

        [SetUp]
        public void Setup()
        {
            _inputValidator = new InputValidator();
        }

        [TestCase("1", 1)]
        [TestCase("6", 6)]
        public void Validate_ShallReturnBackNumber_IfValidatedAsTrue(string input, int expected)
        {
            var result = _inputValidator.Validate(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase("7")]
        [TestCase("0")]
        public void Validate_ShallReturn0_IfValidatedAsFalse(string input)
        {
            var result = _inputValidator.Validate(input);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Validate_ShallReturn0_IfInputIsWord()
        {
            var result = _inputValidator.Validate("two");
            Assert.AreEqual(0, result);
        }
    }
}
