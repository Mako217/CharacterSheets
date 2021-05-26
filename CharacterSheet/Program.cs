using System;
using CharacterSheets.App;
using CharacterSheets.App.Managers;
using CharacterSheets.Domain;

namespace CharacterSheets
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            GroupService groupService = new GroupService();
            CharacterSheetService characterSheetService = new CharacterSheetService();
            GroupManager groupManager = new GroupManager(actionService, groupService, characterSheetService);
            Console.WriteLine("Welcome to your character sheet manager!");
            while (true)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Please select your RPG system:");

                
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
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
                    if (optionInt >= 1 && optionInt <= mainMenu.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Option which you chose does not exist");
                    }
                }

                groupManager.typeSelected = (GroupType)Convert.ToInt32(option.KeyChar.ToString());
                option = groupManager.MenuView();

                switch (option.KeyChar)
                {
                    case '1':
                        int id = groupManager.AddNewGroup();
                        break;
                    case '2':
                        Group groupToRemove = groupManager.SelectGroup();
                        if (groupToRemove != null)
                        {
                            groupManager.RemoveGroup(groupToRemove);
                        }
                        break;
                    case '3':
                        Group groupSelected = groupManager.SelectGroup();
                        if (groupSelected != null)
                        {
                            option = characterSheetService.CharacterSheetView(actionService);
                            switch (option.KeyChar)
                            {
                                case '1':
                                    characterSheetService.AddNewCharacterSheet(groupSelected);
                                    break;
                                case '2':
                                    CharacterSheet characterSheetToRemove = characterSheetService.SelectCharacterSheetView(groupSelected);
                                    if (characterSheetToRemove != null)
                                    {
                                        characterSheetService.RemoveCharacterSheet(characterSheetToRemove);
                                    }
                                    break;
                                case '3':
                                    CharacterSheet characterSheetSelected = characterSheetService.SelectCharacterSheetView(groupSelected);
                                    if (characterSheetSelected != null)
                                    {
                                        characterSheetSelected.ShowCharacterSheetDetails();
                                    }
                                    break;
                            }
                        }
                        break;
                }

            }

        }

        
    }
}
