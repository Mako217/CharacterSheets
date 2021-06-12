﻿using System;
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



        public GroupManager(MenuActionService actionService, IService<Group> groupService, IService<CharacterSheet> characterSheetService) : base(actionService)
        {
            _groupService = groupService;
            _characterSheetService = characterSheetService;
        }

        private readonly IService<Group> _groupService;
        private readonly IService<CharacterSheet> _characterSheetService;

        public override Group SelectItem()
        {
            IEnumerable<Group> validGroups = _groupService.GetValidItems();
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

           GroupService.groupSelected = result;
            Console.WriteLine(GroupService.groupSelected);
            return result;
        }

        public override int AddNewItem()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Enter name for new group:");
            Console.WriteLine(new string('-', 50));
            var name = Console.ReadLine();
            int id = _groupService.GetNewId();
            Group group = new Group(id, name, GroupService.typeSelected);
            _groupService.AddItem(group);

            return id;
        }



        public override void RemoveItem()
        {
            IEnumerable<CharacterSheet> characterSheetsToRemove = _characterSheetService.GetValidItems();
            while (characterSheetsToRemove.Any())
            {
                _characterSheetService.RemoveItem(characterSheetsToRemove.First());
            }
            _groupService.RemoveItem(GroupService.groupSelected);
        }

        public void EditGroup()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Enter new name for a group:");
            Console.WriteLine(new string('-', 50));
            string name = Console.ReadLine();
            GroupService.groupSelected.Name = name;
            _groupService.SaveDataToFile();
        }

    }
}
