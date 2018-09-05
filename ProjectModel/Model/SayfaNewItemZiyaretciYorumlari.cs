using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaNewItemZiyaretciYorumlari")]
    public class SayfaNewItemZiyaretciYorumlari
    {
        [Key]
        public int SayfaNewItemZiyaretciYorumlariId { get; set; }

        public int SayfalarNewItemId { get; set; }

        public string SayfaNewItemZiyaretciYorumlariIsimSoyisim { get; set; }

        public string SayfaNewItemZiyaretciYorumlariYorum { get; set; }

        public bool SayfaNewItemZiyaretciYorumlariOnay { get; set; }

        public string SayfaNewItemZiyaretciYorumlariKonu { get; set; }

        public string SayfalarNewItemVideoResimPath { get; set; }

        public string SayfalarNewItemZiyaretciYorumCevap { get; set; }

        public string SayfaNewItemZiyaretciYorumTarih { get; set; }

    }
}
