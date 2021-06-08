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

        public int attributesCount { get; protected set; }

        public abstract string GetCharacterSheetDetails();
    }

    public class WarhammerCharacterSheet : CharacterSheet
    {
        
        public WarhammerCharacterSheet()
        {
            attributesCount = 20;
        }
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
            stringBuilder.AppendLine($"1. Name: {Name}");
            stringBuilder.AppendLine($"2. Age: {Age}");
            stringBuilder.AppendLine($"3. Sex: {Sex}");
            stringBuilder.AppendLine($"4. Race: {Race}");
            stringBuilder.AppendLine($"5. Weapon Skill: {WeaponSkill}");
            stringBuilder.AppendLine($"6. Ballistic Skill: {BallisticSkill}");
            stringBuilder.AppendLine($"7. Strength: {Strength}");
            stringBuilder.AppendLine($"8. Toughness: {Toughness}");
            stringBuilder.AppendLine($"9. Agility: {Agility}");
            stringBuilder.AppendLine($"10. Intelligence: {Intelligence}");
            stringBuilder.AppendLine($"11. Will Power: {WillPower}");
            stringBuilder.AppendLine($"12. Fellowship: {Fellowship}");
            stringBuilder.AppendLine($"13. Attacks: {Attacks}");
            stringBuilder.AppendLine($"14. Wounds: {Wounds}");
            stringBuilder.AppendLine($"15. Strength Bonus: {StrengthBonus}");
            stringBuilder.AppendLine($"16. Toughness Bonus: {ToughnessBonus}");
            stringBuilder.AppendLine($"17. Movement: {Movement}");
            stringBuilder.AppendLine($"18. Magic: {Magic}");
            stringBuilder.AppendLine($"19. Insanity Points: {InsanityPoints}");
            stringBuilder.AppendLine($"20. Fate Points: {FatePoints}");
            return stringBuilder.ToString();
        }
    }

    public class SavageWorldsCharacterSheet : CharacterSheet
    {
        public SavageWorldsCharacterSheet()
        {
            attributesCount = 13;
        }

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
            stringBuilder.AppendLine($"1. Name: {Name}");
            stringBuilder.AppendLine($"2. Age: {Age}");
            stringBuilder.AppendLine($"3. Sex: {Sex}");
            stringBuilder.AppendLine($"4. Race: {Race}");
            stringBuilder.AppendLine($"5. Agility: {Agility}");
            stringBuilder.AppendLine($"6. Fighting: {Fighting}");
            stringBuilder.AppendLine($"7. Smarts: {Smarts}");
            stringBuilder.AppendLine($"8. Spirit: {Spirit}");
            stringBuilder.AppendLine($"9. Strength: {Strength}");
            stringBuilder.AppendLine($"10. Vigor: {Vigor}");
            stringBuilder.AppendLine($"11. Pace: {Pace}");
            stringBuilder.AppendLine($"12. Parry: {Parry}");
            stringBuilder.AppendLine($"13. Toughness: {Toughness}");
            return stringBuilder.ToString();
        }
    }

    public class CallOfCthulhuCharacterSheet : CharacterSheet
    {
        public CallOfCthulhuCharacterSheet()
        {
            attributesCount = 16;
        }

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
            stringBuilder.AppendLine($"1. Name: {Name}");
            stringBuilder.AppendLine($"2. Age: {Age}");
            stringBuilder.AppendLine($"3. Sex: {Sex}");
            stringBuilder.AppendLine($"4. Occupation: {Occupation}");
            stringBuilder.AppendLine($"5. Strength: {Strength}");
            stringBuilder.AppendLine($"6. Dexterity: {Dexterity}");
            stringBuilder.AppendLine($"7. Power: {Power}");
            stringBuilder.AppendLine($"8. Constitution: {Constitution}");
            stringBuilder.AppendLine($"9. Appearance: {Appearance}");
            stringBuilder.AppendLine($"10. Education: {Education}");
            stringBuilder.AppendLine($"11. Size: {Size}");
            stringBuilder.AppendLine($"12. Intelligence: {Intelligence}");
            stringBuilder.AppendLine($"13. Hit Points: {HitPoints}");
            stringBuilder.AppendLine($"14. Luck: {Luck}");
            stringBuilder.AppendLine($"15. Sanity: {Sanity}");
            stringBuilder.AppendLine($"16. Magic Points: {MagicPoints}");
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
