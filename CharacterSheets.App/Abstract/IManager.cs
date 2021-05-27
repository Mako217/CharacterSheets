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
        ConsoleKeyInfo MenuView();
        T SelectItem();
        int AddNewItem();
        void RemoveItem(T itemToRemove);

    }
}
