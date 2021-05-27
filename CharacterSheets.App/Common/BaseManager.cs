using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Abstract;
using CharacterSheets.Domain;
using CharacterSheets.Domain.Common;

namespace CharacterSheets.App.Common
{
    public class BaseManager<T> : IManager<T> where T : BaseEntity
    {

        public BaseManager(MenuActionService actionService, GroupService groupService, CharacterSheetService characterSheetService)
        {
            _groupService = groupService;
            _actionService = actionService;
            _characterSheetService = characterSheetService;
        }

        private readonly IService<MenuAction> _actionService;
        private readonly IService<Group> _groupService;
        private readonly IService<CharacterSheet> _characterSheetService;

        public ConsoleKeyInfo MenuView()
        {
            string menuName = typeof(T).Name;
            var menu = ((MenuActionService)_actionService).GetMenuActionsByMenuName(menuName);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Please, choose what you want to do:");
            foreach (var action in menu)
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
                if (optionInt >= 1 && optionInt <= menu.Count)
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

        public virtual T SelectItem()
        {
            throw new NotImplementedException();
        }

        public virtual int AddNewItem()
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveItem(T itemToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
