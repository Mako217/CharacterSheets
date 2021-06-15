using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CharacterSheets.App.Abstract;
using CharacterSheets.App.Common;
using CharacterSheets.Domain;

namespace CharacterSheets.App
{
    public class GroupService : BaseService<Group>, IGroupService
    {

        public Group groupSelected { get; set; }
        public GroupType typeSelected { get; set; }

        public GroupService()
        {
            fileName = @"GroupServiceData.json";
            path = directory + fileName;
            CreateFileIfNotExists();

        }

        public IEnumerable<Group> GetGroupsByTypeSelected()
        {
            IEnumerable<Group> validGroups = from grp in Items
                                             where grp.Type == typeSelected
                                             select grp;

            return validGroups;
        }
    }
}
