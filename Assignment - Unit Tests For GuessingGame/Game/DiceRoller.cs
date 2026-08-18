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
    internal class DiceRoller : IRoller
    {
        readonly Random _random;
        const int MaxRoll = 6;

        public DiceRoller(Random random)
        {
            _random = random;
        }

        public int Roll() => _random.Next(1, MaxRoll + 1);
    }
}
