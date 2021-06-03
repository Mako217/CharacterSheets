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
            CharacterSheetManager characterSheetManager =
                new CharacterSheetManager(actionService, characterSheetService);
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

                groupService.typeSelected = (GroupType)Convert.ToInt32(option.KeyChar.ToString());
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
                        if (characterSheetService.groupSelected != null)
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
                            }
                        }
                        break;
                }

            }

        }

        
    }
}
