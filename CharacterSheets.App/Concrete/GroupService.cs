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

        public IEnumerable<Group> GetGroupsByType(GroupType type)
        {
            IEnumerable<Group> validGroups = from grp in Items
                where grp.Type == type
                select grp;

            return validGroups;
        }


    }
}
