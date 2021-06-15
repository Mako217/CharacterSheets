using CharacterSheets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheets.App.Abstract
{
    public interface IGroupService: IService<Group>
    {
        public Group groupSelected { get; set; }
        public GroupType typeSelected { get; set; }
        public IEnumerable<Group> GetGroupsByTypeSelected();
    }
}
