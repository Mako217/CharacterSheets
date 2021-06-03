using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.Domain.Common;

namespace CharacterSheets.Domain
{
    public abstract class CharacterSheet : BaseEntity
    {
        public int GroupId { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public abstract string GetCharacterSheetDetails();
    }

    public class WarhammerCharacterSheet : CharacterSheet
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

        public override string GetCharacterSheetDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(new string('-', 50));
            stringBuilder.AppendLine("Warhammer character sheet");
            stringBuilder.AppendLine(new string('-', 50));
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Age: {Age}");
            stringBuilder.AppendLine($"Sex: {Sex}");
            stringBuilder.AppendLine($"Race: {Race}");
            stringBuilder.AppendLine($"Weapon Skill: {WeaponSkill}");
            stringBuilder.AppendLine($"Ballistic Skill: {BallisticSkill}");
            stringBuilder.AppendLine($"Strength: {Strength}");
            stringBuilder.AppendLine($"Toughness: {Toughness}");
            stringBuilder.AppendLine($"Agility: {Agility}");
            stringBuilder.AppendLine($"Intelligence: {Intelligence}");
            stringBuilder.AppendLine($"Will Power: {WillPower}");
            stringBuilder.AppendLine($"Fellowship: {Fellowship}");
            stringBuilder.AppendLine($"Attacks: {Attacks}");
            stringBuilder.AppendLine($"Wounds: {Wounds}");
            stringBuilder.AppendLine($"Strength Bonus: {StrengthBonus}");
            stringBuilder.AppendLine($"Toughness Bonus: {ToughnessBonus}");
            stringBuilder.AppendLine($"Movement: {Movement}");
            stringBuilder.AppendLine($"Magic: {Magic}");
            stringBuilder.AppendLine($"Insanity Points: {InsanityPoints}");
            stringBuilder.AppendLine($"Fate Points: {FatePoints}");
            return stringBuilder.ToString();
        }
    }

    public class SavageWorldsCharacterSheet : CharacterSheet
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

        public override string GetCharacterSheetDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(new string('-', 50));
            stringBuilder.AppendLine("Savage Worlds character sheet");
            stringBuilder.AppendLine(new string('-', 50));
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Age: {Age}");
            stringBuilder.AppendLine($"Sex: {Sex}");
            stringBuilder.AppendLine($"Race: {Race}");
            stringBuilder.AppendLine($"Agility: {Agility}");
            stringBuilder.AppendLine($"Fighting: {Fighting}");
            stringBuilder.AppendLine($"Smarts: {Smarts}");
            stringBuilder.AppendLine($"Spirit: {Spirit}");
            stringBuilder.AppendLine($"Strength: {Strength}");
            stringBuilder.AppendLine($"Vigor: {Vigor}");
            stringBuilder.AppendLine($"Pace: {Pace}");
            stringBuilder.AppendLine($"Parry: {Parry}");
            stringBuilder.AppendLine($"Toughness: {Toughness}");
            return stringBuilder.ToString();
        }
    }

    public class CallOfCthulhuCharacterSheet : CharacterSheet
    {
        public string Occupation { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Power { get; set; }
        public int Constitution { get; set; }
        public int Appearance { get; set; }
        public int Education { get; set; }
        public int Size { get; set; }
        public int Intelligence { get; set; }
        public int HitPoints { get; set; }
        public int Luck { get; set; }
        public int Sanity { get; set; }
        public int MagicPoints { get; set; }
        
        public override string GetCharacterSheetDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(new string('-', 50));
            stringBuilder.AppendLine("Call of Cthulhu character sheet");
            stringBuilder.AppendLine(new string('-', 50));
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Age: {Age}");
            stringBuilder.AppendLine($"Sex: {Sex}");
            stringBuilder.AppendLine($"Occupation: {Occupation}");
            stringBuilder.AppendLine($"Strength: {Strength}");
            stringBuilder.AppendLine($"Dexterity: {Dexterity}");
            stringBuilder.AppendLine($"Power: {Power}");
            stringBuilder.AppendLine($"Constitution: {Constitution}");
            stringBuilder.AppendLine($"Appearance: {Appearance}");
            stringBuilder.AppendLine($"Education: {Education}");
            stringBuilder.AppendLine($"Size: {Size}");
            stringBuilder.AppendLine($"Intelligence: {Intelligence}");
            stringBuilder.AppendLine($"Hit Points: {HitPoints}");
            stringBuilder.AppendLine($"Luck: {Luck}");
            stringBuilder.AppendLine($"Sanity: {Sanity}");
            stringBuilder.AppendLine($"Magic Points: {MagicPoints}");
            return stringBuilder.ToString();
        }
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
