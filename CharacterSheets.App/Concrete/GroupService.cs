using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CharacterSheets.App.Common;
using CharacterSheets.Domain;

namespace CharacterSheets.App
{
    public class GroupService : BaseService<Group>
    {

        public static Group groupSelected { get; set; }
        public static GroupType typeSelected { get; set; }

        public GroupService()
        {
            fileName = @"GroupServiceData.json";
            path = directory + fileName;
            CreateFileIfNotExists();

        }

        public override IEnumerable<Group> GetValidItems()
        {
            IEnumerable<Group> validGroups = from grp in Items
                                             where grp.Type == typeSelected
                                             select grp;

            return validGroups;
        }
    }
}
