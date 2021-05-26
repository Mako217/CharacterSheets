using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheets.Domain.Common
{
    public class AuditableModel
    {
        public int CreatedById { get; set; }

        public DateTime CreatedDateTime { get; set; }    

        public int? ModifiedById { get; set; }

        public DateTime? ModifiedDateDime { get; set; }
    }
}
