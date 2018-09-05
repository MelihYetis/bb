using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaNewItemZiyaretciYorumlariMedya")]
    public class SayfaNewItemZiyaretciYorumlariMedya
    {
        [Key]
        public int SayfaNewItemZiyaretciYorumlariMedyaId { get; set; }

        public int SayfalarNewItemId { get; set; }

        public string SayfalarNewItemVideoResimPath { get; set; }

        public int SayfaNewItemZiyaretciYorumlariId { get; set; }

        public bool SayfaNewItemZiyaretciResimOnay { get; set; }
    }
}
