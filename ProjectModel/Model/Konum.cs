using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("webkonummust")]
    public class Konum
    {
        [Key]
        public int Id { get; set; }

        public int TALEPID { get; set; }

        public string UNVANI { get; set; }

        public string ADRESI { get; set; }

        public decimal LAT { get; set; }

        public decimal LNG { get; set; }

        public string TLF { get; set; }

        public string GSM { get; set; }
    }
}
