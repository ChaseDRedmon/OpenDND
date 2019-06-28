using System;
using System.Text.RegularExpressions;

namespace OpenDND.Services
{
    public class DiceReader
    {
        private static Regex _regex;
        
        public DiceReader()
        {
            _regex = new Regex(@"(?<quantity>\d{0,2})(?:d|D)(?<sides>(100|4|6|8|10|12|20))");
        }

        public bool TryParseDiceRoll(string input, out Die result)
        {
            throw new NotImplementedException();
        }
    }

    public class Die
    {
        public int DieRoll { get; set; }
        public int Rolls { get; set; }
        public int BaseDamage { get; set; }
    }
}