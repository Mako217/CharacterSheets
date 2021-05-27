using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Abstract;
using CharacterSheets.App.Common;
using CharacterSheets.Domain;

namespace CharacterSheets.App.Managers
{
    public class GroupManager : BaseManager<Group>
    {



        public GroupManager(MenuActionService actionService, GroupService groupService, CharacterSheetService characterSheetService) : base(actionService, groupService, characterSheetService)
        {
        }

        public override Group SelectItem()
        {
            IEnumerable<Group> validGroups = ((GroupService)_groupService).GetGroupsByType();
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

        public override int AddNewItem()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Enter name for new group:");
            Console.WriteLine(new string('-', 50));
            var name = Console.ReadLine();
            int id = _groupService.GetNewId();
            Group group = new Group(id, name, ((GroupService)_groupService).typeSelected);
            _groupService.AddItem(group);

            return id;
        }



        public override void RemoveItem(Group groupToRemove)
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
