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
        public GroupType typeSelected { get; set; }

        public GroupService()
        {
            path = @"CharacterSheets.App\Data\GroupServiceData.json";
            CreateFileIfNotExists();
        }

        public IEnumerable<Group> GetGroupsByType()
        {
            IEnumerable<Group> validGroups = from grp in Items
                where grp.Type == typeSelected
                select grp;

            return validGroups;
        }
    }
}
