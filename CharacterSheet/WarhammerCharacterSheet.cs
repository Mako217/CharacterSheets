using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheets
{
    public class WarhammerCharacterSheet: CharacterSheet
    {
        public string CareerPath { get; set; }
        public string Race { get; set; }
        public int WeaponSkill { get; set; }
        public int BallisticSkill { get; set; }
        public int Strength { get; set; }
        public int Toughness { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int WillPower { get; set; }
        public int Fellowship { get; set; }

        public int Attacks { get; set; }
        public int Wounds { get; set; }
        public int StrengthBonus { get; set; }
        public int ToughnessBonus { get; set; }
        public int Movement { get; set; }
        public int Magic { get; set; }
        public int InsanityPoints { get; set; }
        public int FatePoints { get; set; }
    }
}
