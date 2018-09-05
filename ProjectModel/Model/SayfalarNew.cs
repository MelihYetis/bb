using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfalarNew")]
    public class SayfalarNew
    {
        [Key]
        public int SayfaNewId { get; set; }

        public string SayfaNewAdi { get; set; }

        public int SayfaNewOnSayfa { get; set; }

        [MaxLength(70)]
        [Index(IsUnique = true)]
        public string SayfaNewSeoLink { get; set; }

        public string SayfaNewMetaTitle { get; set; }

        public string SayfaNewMetaDescription { get; set; }

        public string SayfaNewAnahtarKelimeler { get; set; }

        public bool KullaniciGirisAktifPasif { get; set; }

        public bool SolMenuId { get; set; }

        public int SolMenuGrupId { get; set; }

        public string BackgroundImage { get; set; }
    }
}
