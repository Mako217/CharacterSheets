using System;

namespace CharacterSheets
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            GroupService groupService = new GroupService();
            CharacterSheetService characterSheetService = new CharacterSheetService();
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
            
                Enum.TryParse(option.KeyChar.ToString(), out GroupType typeSelected);
                option = groupService.GroupMenuView(actionService);

                switch (option.KeyChar)
                {
                    case '1':
                        int id = groupService.AddGroup(typeSelected);
                        break;
                    case '2':
                        Group groupToRemove = groupService.SelectGroupView(typeSelected);
                        if (groupToRemove != null)
                        {
                            groupService.RemoveGroup(characterSheetService, groupToRemove);
                        }
                        break;
                    case '3':
                        Group groupSelected = groupService.SelectGroupView(typeSelected);
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
                                    characterSheetService.RemoveCharacterSheet(characterSheetToRemove);
                                    break;
                                case '3':
                                    CharacterSheet characterSheetSelected = characterSheetService.SelectCharacterSheetView(groupSelected);
                                    characterSheetService.ShowCharacterSheetDetails(characterSheetSelected, groupSelected);
                                    break;
                            }
                        }
                        break;
                }

            }

        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Warhammer 2nd edition", "Main");
            actionService.AddNewAction(2, "Savage Worlds", "Main");
            actionService.AddNewAction(3, "Call of Cthulhu 7th edition", "Main");

            actionService.AddNewAction(1, "Add group", "Group");
            actionService.AddNewAction(2, "Remove group", "Group");
            actionService.AddNewAction(3, "Select group", "Group");

            actionService.AddNewAction(1, "Add character sheet", "Character Sheet");
            actionService.AddNewAction(2, "Remove character sheet", "Character Sheet");
            actionService.AddNewAction(3, "Show character sheet details", "Character Sheet");
            return actionService;
        }
    }
}
