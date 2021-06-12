using System;
using System.Collections.Generic;
using System.IO;
using CharacterSheets.App;
using CharacterSheets.App.Abstract;
using CharacterSheets.App.Managers;
using CharacterSheets.Domain;

namespace CharacterSheets
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            Directory.SetCurrentDirectory(@"..\..\..\..");
            MenuActionService actionService = new MenuActionService();
            IService<Group> groupService = new GroupService(@"CharacterSheets.App\Data\GroupServiceData.json");
            groupService.CreateFileIfNotExists();
            IService<CharacterSheet> characterSheetService = new CharacterSheetService(@"CharacterSheets.App\Data\CharacterSheetServiceData.json");
            characterSheetService.CreateFileIfNotExists();
            GroupManager groupManager = new GroupManager(actionService, groupService, characterSheetService);
            CharacterSheetManager characterSheetManager =
                new CharacterSheetManager(actionService, characterSheetService);
            Console.WriteLine("Welcome to your character sheet manager!");
            while (true)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Please select your RPG system:");
                actionService.menuName = "Main";
                List<MenuAction> mainMenu = (List<MenuAction>)actionService.GetValidItems();
                foreach (var action in mainMenu)
                {
                    Console.WriteLine($"{action.Id}. {action.Name}");
                }

                ConsoleKeyInfo option;
                int optionInt;
                while (true)
                {
                    Console.WriteLine(new string('-', 50));
                    option = Console.ReadKey();
                    Console.WriteLine();
                    Int32.TryParse(option.KeyChar.ToString(), out optionInt);
                    if (optionInt >= 1 && optionInt < mainMenu.Count)
                    {
                        break;
                    }
                    else if(optionInt == mainMenu.Count)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Option which you chose does not exist");
                    }
                }

                GroupService.typeSelected = (GroupType)Convert.ToInt32(option.KeyChar.ToString());
                option = groupManager.MenuView();

                switch (option.KeyChar)
                {
                    case '1':
                        int id = groupManager.AddNewItem();
                        break;
                    case '2':
                        Group groupToRemove = groupManager.SelectItem();
                        if (groupToRemove != null) 
                        {
                            groupManager.RemoveItem();
                        }
                        break;
                    case '3':
                        groupManager.SelectItem();
                        if (GroupService.groupSelected != null)
                        {
                            option = characterSheetManager.MenuView();
                            switch (option.KeyChar)
                            {
                                case '1':
                                    characterSheetManager.AddNewItem();
                                    break;
                                case '2':
                                    CharacterSheet characterSheetToRemove = characterSheetManager.SelectItem();
                                    if (characterSheetToRemove != null)
                                    {
                                        characterSheetManager.RemoveItem();
                                    }
                                    break;
                                case '3':
                                    CharacterSheet characterSheetSelected = characterSheetManager.SelectItem();
                                    if (characterSheetSelected != null)
                                    {
                                        characterSheetManager.ShowCharacterSheetDetails();
                                    }
                                    break;
                                case '4':
                                    CharacterSheet characterSheetToEdit = characterSheetManager.SelectItem();
                                    if (characterSheetToEdit != null)
                                    {
                                        characterSheetManager.EditCharacterSheet();
                                    }
                                    break;
                                case '5':
                                    break;
                            }
                        }
                        break;
                    case '4':
                        Group groupToEdit = groupManager.SelectItem();
                        if(groupToEdit!=null)
                        {
                            groupManager.EditGroup();
                        }
                        break;
                    case '5':
                        break;
                }

            }

        }

        
    }
}
