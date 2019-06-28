using System;
using System.Linq;

namespace OpenDND.Services.Core
{
    public class RollDiceService
    {
        private static Random rand;
        private static object randLock;
        private readonly int[] validNumbers = { 4, 6, 8, 10, 12, 20, 100 };

        public RollDiceService()
        {
            rand = new Random();
            randLock = new object();
        }

        public int Roll(int maxValue)
        {
            var check = validNumbers.Any(x => x == maxValue);

            if (!check)
            {
                throw new ArgumentException($"{maxValue} is not valid");
            }

            return rand.Next(1, maxValue + 1);
        }
    }
}