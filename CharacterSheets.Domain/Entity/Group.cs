using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.Domain.Common;

namespace CharacterSheets.Domain
{
    public class Group : BaseEntity
    {
        public GroupType Type { get; set; }

        public Group(int id, string name, GroupType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

    }

    public enum GroupType
    {
        Warhammer = 1,
        SavageWorlds,
        CallOfCthulhu
    }
}
