using System;
using System.Linq;

namespace OpenDND.Services.Core
{
    public enum MaximumDieValues
    {
        D2 = 2,
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D100 = 100
    }
    
    public class RollDiceService
    {
        private static Random _random;

        public RollDiceService()
        {
            _random = new Random();
        }
        
        // Todo: Create methods for rolling single die rolls and rolling multiple dies at the same time
        public int Roll(MaximumDieValues die)
        {
            var max = (int) die;
            var roll = _random.Next(1, max + 1);
            return roll;
        }
    }
}