using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("MusteriSiparisItem")]
    public class MusteriSiparisItem
    {
        [Key]
        public int MusteriSiparisItemId { get; set; }

        public int SiparisUrunId { get; set; }

        public string SiparisUrunAdi { get; set; }

        public double SiparisUrunFiyati { get; set; }

        public int SiparisUrunAdet { get; set; }

        public int MusteriSiparisId { get; set; }
    }
}
