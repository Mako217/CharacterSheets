using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Common;
using CharacterSheets.Domain;

namespace CharacterSheets.App
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Warhammer 2nd edition", "Main"));
            AddItem(new MenuAction(2, "Savage Worlds", "Main"));
            AddItem(new MenuAction(3, "Call of Cthulhu 7th edition", "Main"));

            AddItem(new MenuAction(1, "Add group", "Group"));
            AddItem(new MenuAction(2, "Remove group", "Group"));
            AddItem(new MenuAction(3, "Select group", "Group"));

            AddItem(new MenuAction(1, "Add character sheet", "CharacterSheet"));
            AddItem(new MenuAction(2, "Remove character sheet", "CharacterSheet"));
            AddItem(new MenuAction(3, "Show character sheet details", "CharacterSheet"));
        }
    }
}
