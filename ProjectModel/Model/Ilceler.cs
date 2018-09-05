using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("Ilceler")]
    public class Ilceler
    {
        [Key]
        public int IlceId { get; set; }

        public string IlceAdi { get; set; }

        public int IlId { get; set; }
    }
}
