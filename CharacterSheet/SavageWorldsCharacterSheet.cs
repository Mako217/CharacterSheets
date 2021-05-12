using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheets
{
    public class SavageWorldsCharacterSheet: CharacterSheet
    {
        public string Race { get; set; }
        public DiceType Agility { get; set; }
        public DiceType Fighting { get; set; }
        public DiceType Smarts { get; set; }
        public DiceType Spirit { get; set; }
        public DiceType Strength { get; set; }
        public DiceType Vigor { get; set; }
        public int Pace { get; set; }
        public int Parry { get; set; }
        public int Toughness { get; set; }
    }

    public enum DiceType
    {
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12
    }
}
