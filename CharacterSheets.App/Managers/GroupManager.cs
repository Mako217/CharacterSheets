using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Abstract;
using CharacterSheets.Domain;

namespace CharacterSheets.App.Managers
{
    public class GroupManager
    {
        private readonly MenuActionService _actionService;
        private GroupService _groupService;
        private CharacterSheetService _characterSheetService;
        public GroupType typeSelected { get; set; }

        public GroupManager(MenuActionService actionService, GroupService groupService, CharacterSheetService characterSheetService)
        {
            _groupService = groupService;
            _actionService = actionService;
            _characterSheetService = characterSheetService;
        }

        public ConsoleKeyInfo MenuView()
        {
            var groupMenu = _actionService.GetMenuActionsByMenuName("Group");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Please, choose what you want to do:");
            foreach (var action in groupMenu)
            {
                Console.WriteLine($"{action.Id}. {action.Name}");
            }

            ConsoleKeyInfo option;
            while (true)
            {
                Console.WriteLine(new string('-', 50));
                option = Console.ReadKey();
                Console.WriteLine();
                Int32.TryParse(option.KeyChar.ToString(), out int optionInt);
                if (optionInt >= 1 && optionInt <= groupMenu.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Option which you chose does not exist");
                }
            }

            return option;
        }

        public int AddNewGroup()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Enter name for new group:");
            Console.WriteLine(new string('-', 50));
            var name = Console.ReadLine();
            int id = _groupService.GetNewId();
            Group group = new Group(id, name, typeSelected);
            _groupService.AddItem(group);

            return id;
        }

        public Group SelectGroup()
        {
            IEnumerable<Group> validGroups = _groupService.GetGroupsByType(typeSelected);
            Group result;

            if (validGroups.Any())
            {
                int selectedId;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Enter ID to select group:");
                foreach (var group in validGroups)
                {
                    Console.WriteLine($"{group.Name} ID: {group.Id}");
                }

                while (true)
                {
                    Console.WriteLine(new string('-', 50));
                    Int32.TryParse(Console.ReadLine(), out selectedId);
                    if (validGroups.Any(grp => grp.Id == selectedId))
                    {
                        result = _groupService.GetItemById(selectedId);
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
                Console.WriteLine("There are no groups");
                result = null;
            }

            return result;
        }

        public void RemoveGroup(Group groupToRemove)
        {
            IEnumerable<CharacterSheet> characterSheetsToRemove = from sheet in _characterSheetService.Items
                where sheet.GroupId == groupToRemove.Id
                select sheet;
            while (characterSheetsToRemove.Any())
            {
                _characterSheetService.RemoveItem(characterSheetsToRemove.First());
            }
            _groupService.RemoveItem(groupToRemove);
        }


    }
}
