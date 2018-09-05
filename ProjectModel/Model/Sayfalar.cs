using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectModel.Model
{
    [Table("Sayfalar")]
    public class Sayfalar
    {
        [Key]
        public int SayfaId { get; set; }

        public string SayfaAdi { get; set; }

        public string DefOzl { get; set; }

        public string SabitSayfa { get; set; }

        public int SayfaSatirSayisi { get; set; }

        public int SayfaSatirModeli { get; set; }

        public int SayfaSutunSayisi { get; set; }

        public int SayfaSatir2Modeli { get; set; }

        public int SayfaSutun2Sayisi { get; set; }

        public int SayfaSatir3Modeli { get; set; }

        public int SayfaSutun3Sayisi { get; set; }

        public int SayfaSatir4Modeli { get; set; }

        public int SayfaSutun4Sayisi { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string AnahtarKelimeler { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaUstYazi { get; set; }

        [MaxLength(70)]
        [Index(IsUnique = true)]
        public string SeoLink { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaMetinAciklama { get; set; }

        public bool SayfaMetinAciklamaAktifPasif { get; set; }

        public string SayfaMetinYeri { get; set; }

        
    }
}
