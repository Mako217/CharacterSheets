using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CharacterSheets.App.Abstract;
using CharacterSheets.App.Common;
using CharacterSheets.Domain;

namespace CharacterSheets.App
{
    public class CharacterSheetService : BaseService<CharacterSheet>, ICharacterSheetService
    {

        public CharacterSheet characterSheetSelected { get; set; }

        public CharacterSheetService()
        {
            fileName = @"CharacterSheetServiceData.json";
            path = directory + fileName;
            CreateFileIfNotExists();
        }


        public IEnumerable<CharacterSheet> GetCharacterSheetsByGroup(Group groupSelected)
        {
            IEnumerable<CharacterSheet> validCharacterSheets = from chs in Items
                                                               where chs.GroupId == groupSelected.Id
                                                               select chs;

            return validCharacterSheets;
        }
    }

}
