using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterSheets
{
    public class GroupService
    {
        private List<Group> Groups = new List<Group>();

        public ConsoleKeyInfo GroupMenuView(MenuActionService actionService)
        {
            var groupMenu = actionService.GetMenuActionsByMenuName("Group");
            Console.WriteLine(new string('-',50));
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

        public int AddGroup(GroupType TypeSelected)
        {
            Console.WriteLine(new string('-',50));
            Console.WriteLine("Enter name for new group:");
            Console.WriteLine(new string('-', 50));
            var name = Console.ReadLine();
            int id;
            if (Groups.Any())
            {
                id = Groups.Last().Id + 1;
            }
            else
            {
                id = 1;
            }
            Groups.Add(new Group(){Id = id, Name = name, Type = TypeSelected});

            return id;
        }


        public void RemoveGroup(CharacterSheetService characterSheetService,Group groupToRemove)
        {
            IEnumerable<CharacterSheet> characterSheetsToRemove = from sheet in characterSheetService.CharacterSheets
                where sheet.GroupId == groupToRemove.Id
                select sheet;
            while (characterSheetsToRemove.Any())
            {
                characterSheetService.RemoveCharacterSheet(characterSheetsToRemove.First());
            }
            Groups.Remove(groupToRemove);
        }

        public Group SelectGroupView(GroupType TypeSelected)
        {
            Group result;
            int selectedId;
            IEnumerable<Group> validGroups = from grp in Groups
                where grp.Type == TypeSelected
                select grp;

            if (validGroups.Any())
            {
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
                    Console.WriteLine();
                    if (validGroups.Any(grp => grp.Id == selectedId))
                    {
                        result = validGroups.Single(grp => grp.Id == selectedId);
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

    }
}
