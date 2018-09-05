using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("TasarimSablonOzellik")]
    public class TasarimSablonOzellik
    {
        [Key]
        public int TasarimSablonOzelikId { get; set; }

        public int TasarimSablonId { get; set; }

        public int SablonOzellik { get; set; }

        public string TasarimSablonTipAdi { get; set; }
    }
}
