using PagedList;
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
    [Table("Urunler")]
    public class Urunler
    {
        [Key]
        public int UrunId { get; set; }

        public string UrunAdi { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string UrunAciklama { get; set; }

        public byte [] UrunResmi { get; set; }

        public int UstKategoriId { get; set; }

        public int AltKategoriId { get; set; }

        public int BirAltKategoriId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string UrunKisaAciklama { get; set; }

        public string UrunPiyasaFiyati { get; set; }

        public string UrunSatisFiyati { get; set; }

        public string ParaBirimi { get; set; }

        public string UrunMetaTitle { get; set; }

        public string UrunMetaDescription { get; set; }

        public string UrunAnahtarKelimeler { get; set; }

        
        public string SeoLink { get; set; }

        [NotMapped]
        public string UrunResimImagePath { get; set; }
        [NotMapped]
        public int BedenId { get; set; }

        public bool UrunAnaSayfa { get; set; }

        public bool UrunYeniUrun { get; set; }

        public string UrunKodu { get; set; }

        [NotMapped]
        public IPagedList<Urunler> ListUrun { get; set; }

        [NotMapped]
        public int? SayfaNumarasi { get; set; }

        public int TabAdet { get; set; }

        public string OnlineLink { get; set; }
    }
}
