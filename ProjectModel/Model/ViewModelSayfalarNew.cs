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
    public class ViewModelSayfalarNew
    {
        public int SayfaNewId { get; set; }

        public string SayfaNewAdi { get; set; }


        [MaxLength(70)]
        [Index(IsUnique = true)]
        public string SayfaNewSeoLink { get; set; }

        public string SayfaNewMetaTitle { get; set; }

        public string SayfaNewMetaDescription { get; set; }

        public string SayfaNewAnahtarKelimeler { get; set; }

        //SayfalarNewItem
        public int SayfaNewItemTip { get; set; }

        public string SayfaNewItemBaslik { get; set; }

        public int SayfalarNewItemId { get; set; }

        public int SayfaItemSatirKolonSayisi { get; set; }

        public string SayfaNewItemArkaPlanRenk { get; set; }

        public int SayfaItemSiraNo { get; set; }

        //SayfalarNewItemMetin
        public int SayfaNewItemMetinId { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemMetinAciklama { get; set; }

        //SayfalarNewItemGaleri
        public int SayfaNewItemGaleriId { get; set; }

        public string SayfalarNewItemResimPath { get; set; }

        public string SayfalarNewItemResimAciklama { get; set; }
        //SayfalarNewItemParallax
        public int SayfaNewItemParallaxId { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemParallaxAciklama { get; set; }

        public string SayfalarNewItemParallaxResimPath { get; set; }

        //SayfalarNewItemSlider
        public int SayfaNewItemSliderId { get; set; }

        public string SayfalarNewSliderResimPath { get; set; }

        public string SayfalarNewItemSliderAciklama { get; set; }

        //SayfalarNewItemBaslik
        public int SayfaNewItemBaslikId { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemBaslikAciklama { get; set; }

        public string SayfaNewItemBaslikLink { get; set; }


        //SayfalarNewItemIletisim Bilgileri
        public int SayfaNewItemIletisimId { get; set; }
                
        public string SayfaNewItemIletisimTel { get; set; }

        public string SayfaNewItemIletisimFax { get; set; }

        public string SayfaNewItemIletisimEmail { get; set; }

        public string SayfaNewItemIletisimAdres { get; set; }

        public string SayfaNewItemIletisimMaps { get; set; }

        //SayfalarNewItemHaber Blog Yazı

        public int SayfaNewItemYaziId { get; set; }

        public int YaziKategoriId { get; set; }

        public string SayfaNewItemYaziAciklama { get; set; }

        public string YaziKategoriAciklama { get; set; }

        // SayfalarNewItemSlideShow SlideShow

        public int SlideShowId { get; set; }

        public string SlideShowResimPath { get; set; }

        // SayfaNewItemMetinIkili Metin İkili
        public int SayfaNewItemMetinIkiliId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemMetinIkiliAciklamaBir { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemMetinIkiliAciklamaIki { get; set; }


        public int SolMenuGrupId { get; set; }

        public int SayfaReklamId { get; set; }

        public string SayfaReklamYeri { get; set; }

        public string SayfaReklamResimPath { get; set; }

        public string SayfaReklamUrl { get; set; }

        
        //Personel Bilgi
        public int SayfalarNewItemPersonelId { get; set; }

        public string SayfalarNewItemPersonelResimPath { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfalarNewItemPersonelAciklama { get; set; }


        public int SayfaNewItemTabId { get; set; }

        public int SayfaNewItemTabAdet { get; set; }

        public string SayfaNewItemTabAdi { get; set; }

        public int SayfaNewItemTabTip { get; set; }

        public int SayfaNewItemTabItemId { get; set; }
    }
}
