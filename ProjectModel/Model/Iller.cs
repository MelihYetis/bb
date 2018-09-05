using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("Iller")]
    public class Iller
    {
        [Key]
        public int IlId { get; set; }

        public string IlAdi { get; set; }
    }
}
