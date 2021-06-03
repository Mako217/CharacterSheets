﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Common;
using CharacterSheets.Domain;

namespace CharacterSheets.App.Managers
{
    public class CharacterSheetManager : BaseManager<CharacterSheet>
    {
        public CharacterSheetManager(MenuActionService actionService, CharacterSheetService characterSheetService) : base(actionService)
        {
            _characterSheetService = characterSheetService;
        }

        private readonly CharacterSheetService _characterSheetService;

        public override CharacterSheet SelectItem()
        {
            IEnumerable<CharacterSheet> validCharacterSheets = _characterSheetService.GetCharacterSheetByGroup();
            CharacterSheet result;

            if (validCharacterSheets.Any())
            {
                int selectedId;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Enter ID to select character sheet:");
                foreach (var group in validCharacterSheets)
                {
                    Console.WriteLine($"{group.Name} ID: {group.Id}");
                }

                while (true)
                {
                    Console.WriteLine(new string('-', 50));
                    Int32.TryParse(Console.ReadLine(), out selectedId);
                    if (validCharacterSheets.Any(grp => grp.Id == selectedId))
                    {
                        result = _characterSheetService.GetItemById(selectedId);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Option which you chose does not exist");
                    }
                }
            }
            else
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("There are no character sheets");
                result = null;
            }

            _characterSheetService.characterSheetSelected = result;
            return result;
        }

        public override void RemoveItem()
        {
            _characterSheetService.RemoveItem(_characterSheetService.characterSheetSelected);
        }

        public override int AddNewItem()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter sex:");
            string sex = Console.ReadLine();
            Console.WriteLine("Enter age:");
            Int32.TryParse(Console.ReadLine(), out int age);
            int id = _characterSheetService.GetNewId();
            Group group = _characterSheetService.groupSelected;

            switch (group.Type)
            {
                case GroupType.Warhammer:
                    WarhammerCharacterSheet warhammerCharacterSheet = new WarhammerCharacterSheet();
                    warhammerCharacterSheet.Id = id;
                    warhammerCharacterSheet.GroupId = group.Id;
                    warhammerCharacterSheet.Name = name;
                    warhammerCharacterSheet.Sex = sex;
                    warhammerCharacterSheet.Age = age;
                    AddNewWarhammerCharacter(warhammerCharacterSheet);
                    break;
                case GroupType.SavageWorlds:
                    SavageWorldsCharacterSheet savageWorldsCharacterSheet = new SavageWorldsCharacterSheet();
                    savageWorldsCharacterSheet.Id = id;
                    savageWorldsCharacterSheet.GroupId = group.Id;
                    savageWorldsCharacterSheet.Name = name;
                    savageWorldsCharacterSheet.Sex = sex;
                    savageWorldsCharacterSheet.Age = age;
                    AddNewSavageWorldsCharacter(savageWorldsCharacterSheet);
                    break;
                case GroupType.CallOfCthulhu:
                    CallOfCthulhuCharacterSheet callOfCthulhuCharacterSheet = new CallOfCthulhuCharacterSheet();
                    callOfCthulhuCharacterSheet.Id = id;
                    callOfCthulhuCharacterSheet.GroupId = group.Id;
                    callOfCthulhuCharacterSheet.Name = name;
                    callOfCthulhuCharacterSheet.Sex = sex;
                    callOfCthulhuCharacterSheet.Age = age;
                    AddNewCallOfCthulhuCharacter(callOfCthulhuCharacterSheet);
                    break;
            }
            return id;
        }

        private void AddNewWarhammerCharacter(WarhammerCharacterSheet characterSheet)
        {
            Console.WriteLine("Enter Career path:");
            characterSheet.CareerPath = Console.ReadLine();
            Console.WriteLine("Enter Race:");
            characterSheet.Race = Console.ReadLine();
            Console.WriteLine("Enter Weapon Skill:");
            characterSheet.WeaponSkill = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Ballistic Skill:");
            characterSheet.BallisticSkill = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Strength:");
            characterSheet.Strength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Toughness:");
            characterSheet.Toughness = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Agility:");
            characterSheet.Agility = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Intelligence:");
            characterSheet.Intelligence = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Will Power:");
            characterSheet.WillPower = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Fellowship:");
            characterSheet.Fellowship = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Attacks:");
            characterSheet.Attacks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Wounds:");
            characterSheet.Wounds = Convert.ToInt32(Console.ReadLine());
            characterSheet.StrengthBonus = Convert.ToInt32(characterSheet.Strength.ToString().ToCharArray()[0].ToString());
            characterSheet.ToughnessBonus = Convert.ToInt32(characterSheet.Toughness.ToString().ToCharArray()[0].ToString());
            Console.WriteLine("Enter Movement:");
            characterSheet.Movement = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Magic:");
            characterSheet.Magic = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Insanity Points:");
            characterSheet.InsanityPoints = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Fate Points:");
            characterSheet.FatePoints = Convert.ToInt32(Console.ReadLine());

            _characterSheetService.AddItem(characterSheet);
        }

        private void AddNewSavageWorldsCharacter(SavageWorldsCharacterSheet characterSheet)
        {
            Console.WriteLine("Enter Race:");
            characterSheet.Race = Console.ReadLine();
            Console.WriteLine("Enter Agility (4, 6, 8, 10 or 12):");
            while (true)
            {
                int agility = Convert.ToInt32(Console.ReadLine());
                if (agility == 4 || agility == 6 || agility == 8 || agility == 10 || agility == 12)
                {
                    characterSheet.Agility = (DiceType)agility;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }
            Console.WriteLine("Enter Fighting (4, 6, 8, 10 or 12):");
            while (true)
            {
                int fighting = Convert.ToInt32(Console.ReadLine());
                if (fighting == 4 || fighting == 6 || fighting == 8 || fighting == 10 || fighting == 12)
                {
                    characterSheet.Fighting = (DiceType)fighting;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }
            Console.WriteLine("Enter Smarts (4, 6, 8, 10 or 12):");
            while (true)
            {
                int smarts = Convert.ToInt32(Console.ReadLine());
                if (smarts == 4 || smarts == 6 || smarts == 8 || smarts == 10 || smarts == 12)
                {
                    characterSheet.Smarts = (DiceType)smarts;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }
            Console.WriteLine("Enter Spirit (4, 6, 8, 10 or 12):");
            while (true)
            {
                int spirit = Convert.ToInt32(Console.ReadLine());
                if (spirit == 4 || spirit == 6 || spirit == 8 || spirit == 10 || spirit == 12)
                {
                    characterSheet.Spirit = (DiceType)spirit;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }
            Console.WriteLine("Enter Strength (4, 6, 8, 10 or 12):");
            while (true)
            {
                int strength = Convert.ToInt32(Console.ReadLine());
                if (strength == 4 || strength == 6 || strength == 8 || strength == 10 || strength == 12)
                {
                    characterSheet.Strength = (DiceType)strength;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }
            Console.WriteLine("Enter Vigor (4, 6, 8, 10 or 12):");
            while (true)
            {
                int vigor = Convert.ToInt32(Console.ReadLine());
                if (vigor == 4 || vigor == 6 || vigor == 8 || vigor == 10 || vigor == 12)
                {
                    characterSheet.Vigor = (DiceType)vigor;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }
            characterSheet.Pace = 6;
            characterSheet.Parry = ((int)characterSheet.Fighting / 2) + 2;
            characterSheet.Toughness = ((int)characterSheet.Vigor / 2) + 2;
            _characterSheetService.AddItem(characterSheet);
        }

        private void AddNewCallOfCthulhuCharacter(CallOfCthulhuCharacterSheet characterSheet)
        {
            Console.WriteLine("Enter Occupation:");
            characterSheet.Occupation = Console.ReadLine();
            Console.WriteLine("Enter Strength:");
            characterSheet.Strength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Dexterity:");
            characterSheet.Dexterity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Power:");
            characterSheet.Power = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Constitution:");
            characterSheet.Constitution = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Appearance:");
            characterSheet.Appearance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Education:");
            characterSheet.Education = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Size");
            characterSheet.Size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Intelligence");
            characterSheet.Intelligence = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Hit Points");
            characterSheet.HitPoints = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Luck");
            characterSheet.Luck = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Sanity");
            characterSheet.Sanity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Magic Points");
            characterSheet.MagicPoints = Convert.ToInt32(Console.ReadLine());
            _characterSheetService.AddItem(characterSheet);
        }

        public void ShowCharacterSheetDetails()
        {
            Console.WriteLine(_characterSheetService.characterSheetSelected.GetCharacterSheetDetails());
        }

    }
}
