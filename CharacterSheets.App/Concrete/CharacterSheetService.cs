using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Common;
using CharacterSheets.Domain;

namespace CharacterSheets.App
{
    public class CharacterSheetService : BaseService<CharacterSheet>
    {
        public Group groupSelected { get; set; }
        public CharacterSheet characterSheetSelected { get; set; }

        public IEnumerable<CharacterSheet> GetCharacterSheetByGroup()
        {
            IEnumerable<CharacterSheet> validCharacterSheets = from chs in Items
                where chs.GroupId == groupSelected.Id
                select chs;

            return validCharacterSheets;
        }
    }

}
