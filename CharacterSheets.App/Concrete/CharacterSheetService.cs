﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CharacterSheets.App.Common;
using CharacterSheets.Domain;

namespace CharacterSheets.App
{
    public class CharacterSheetService : BaseService<CharacterSheet>
    {

        public static CharacterSheet characterSheetSelected { get; set; }

        public CharacterSheetService(string path)
        {
            Path = path;
        }


        public override IEnumerable<CharacterSheet> GetValidItems()
        {
            IEnumerable<CharacterSheet> validCharacterSheets = from chs in Items
                where chs.GroupId == GroupService.groupSelected.Id
                select chs;

            return validCharacterSheets;
        }
    }

}
