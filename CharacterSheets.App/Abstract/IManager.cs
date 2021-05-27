using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.Domain;

namespace CharacterSheets.App.Abstract
{
    public interface IManager<T>
    {
        IService<MenuAction> _actionService { get; set; }
        IService<Group> _groupService { get; set; }
        IService<CharacterSheet> _characterSheetService { get; set; }

        ConsoleKeyInfo MenuView();
        T SelectItem();
        int AddNewItem();
        void RemoveItem(T itemToRemove);

    }
}
