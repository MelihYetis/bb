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
    [Table("SayfaNewItemSatir")]
    public class SayfaNewItemSatir
    {
        [Key]
        public int SayfaNewtemSatirId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemSatirKolon1Yazi { get; set; }

        public string SayfaNewItemSatirKolon1ResimPath { get; set; }

        public string SayfaNewItemSatirKolon1Link { get; set; }

        public int SayfaNewItemSatirKolon1SayfaLinkId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemSatirKolon2Yazi { get; set; }

        public string SayfaNewItemSatirKolon2ResimPath { get; set; }

        public string SayfaNewItemSatirKolon2Link { get; set; }

        public int SayfaNewItemSatirKolon2SayfaLinkId { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemSatirKolon3Yazi { get; set; }

        public string SayfaNewItemSatirKolon3ResimPath { get; set; }

        public string SayfaNewItemSatirKolon3Link { get; set; }

        public int SayfaNewItemSatirKolon3SayfaLinkId { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemSatirKolon4Yazi { get; set; }

        public string SayfaNewItemSatirKolon4ResimPath { get; set; }

        public string SayfaNewItemSatirKolon4Link { get; set; }

        public int SayfaNewItemSatirKolon4SayfaLinkId { get; set; }
        
        public string SayfaNewItemSatirAllKolon { get; set; }

        public int SayfalarNewItemId { get; set; }

        public string SayfaNewItemSatirKolon1Videolink { get; set; }

        public string SayfaNewItemSatirKolon2Videolink { get; set; }

        public string SayfaNewItemSatirKolon3Videolink { get; set; }

        public string SayfaNewItemSatirKolon4Videolink { get; set; }

        public string SayfaNewItemSatirKolon1ResimAciklama { get; set; }

        public string SayfaNewItemSatirKolon2ResimAciklama { get; set; }

        public string SayfaNewItemSatirKolon3ResimAciklama { get; set; }

        public string SayfaNewItemSatirKolon4ResimAciklama { get; set; }
    }
}
