using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SolMenuGrup")]
    public class SolMenuGrup
    {
        [Key]
        public int SolMenuGrupId { get; set; }

        public string SolMenuGrupAdi { get; set; }

        public int SolMenuBagliSayfa { get; set; }
    }
}
