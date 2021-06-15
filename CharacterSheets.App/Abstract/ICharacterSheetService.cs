using CharacterSheets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheets.App.Abstract
{
    public interface ICharacterSheetService:IService<CharacterSheet>
    {
        public CharacterSheet characterSheetSelected { get; set; }
        IEnumerable<CharacterSheet> GetCharacterSheetsByGroup(Group group);

    }
}
