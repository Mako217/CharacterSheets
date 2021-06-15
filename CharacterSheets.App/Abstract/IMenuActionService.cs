using CharacterSheets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheets.App.Abstract
{
    public interface IMenuActionService: IService<MenuAction>
    {
        IEnumerable<MenuAction> GerActionsByMenuName(string menuName);
    }
}
