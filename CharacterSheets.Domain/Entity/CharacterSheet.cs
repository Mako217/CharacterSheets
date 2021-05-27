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

        public abstract void ShowCharacterSheetDetails();
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

        public override void ShowCharacterSheetDetails()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Career Path: {CareerPath}");
            Console.WriteLine($"Race: {Race}");
            Console.WriteLine($"Weapon Skill: {WeaponSkill}");
            Console.WriteLine($"Ballistic Skill: {BallisticSkill}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Toughness: {Toughness}");
            Console.WriteLine($"Agility: {Agility}");
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Will Power: {WillPower}");
            Console.WriteLine($"Fellowship: {Fellowship}");
            Console.WriteLine($"Attacks: {Attacks}");
            Console.WriteLine($"Wounds: {Wounds}");
            Console.WriteLine($"Strength Bonus: {StrengthBonus}");
            Console.WriteLine($"Toughness Bonus: {ToughnessBonus}");
            Console.WriteLine($"Movement: {Movement}");
            Console.WriteLine($"Magic: {Magic}");
            Console.WriteLine($"Insanity Points: {InsanityPoints}");
            Console.WriteLine($"Fate Points: {FatePoints}");
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

        public override void ShowCharacterSheetDetails()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Race: {Race}");
            Console.WriteLine($"Agility: {Agility}");
            Console.WriteLine($"Fighting: {Fighting}");
            Console.WriteLine($"Smarts: {Smarts}");
            Console.WriteLine($"Spirit: {Spirit}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Vigor: {Vigor}");
            Console.WriteLine($"Pace: {Pace}");
            Console.WriteLine($"Parry: {Parry}");
            Console.WriteLine($"Toughness: {Toughness}");
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
        
        public override void ShowCharacterSheetDetails()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Occupation: {Occupation}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Dexterity: {Dexterity}");
            Console.WriteLine($"Power: {Power}");
            Console.WriteLine($"Constitution: {Constitution}");
            Console.WriteLine($"Appearance: {Appearance}");
            Console.WriteLine($"Education: {Education}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Hit Points: {HitPoints}");
            Console.WriteLine($"Luck: {Luck}");
            Console.WriteLine($"Sanity: {Sanity}");
            Console.WriteLine($"Magic Points: {MagicPoints}");
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
