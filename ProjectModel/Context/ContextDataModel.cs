using MySql.Data.Entity;
using ProjectModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Context
{
    public class ContextDataModel :DbContext
    {
        static ContextDataModel()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());


        }
        
        public DbSet<Banner> Bannerlar { get; set; }
        public DbSet<Sayfalar> Sayfalar { get; set; }
        public DbSet<IletisimItem> IletisimItem { get; set; }
        public DbSet<Haberler> Haberler { get; set; }
        public DbSet<Resimler> Resimler { get; set; }
        public DbSet<SayfalarMetin> SayfalarMetin { get; set; }
        public DbSet<GaleriSayfaResimler> GaleriSayfaResimler { get; set; }
        public DbSet<Menuler> Menuler { get; set; }
        public DbSet<AltMenuler> AltMenuler { get; set; }
        public DbSet<UstKategoriler> UstKategoriler { get; set; }
        public DbSet<BirAltMenuler> BirAltMenuler { get; set; }
        public DbSet<AltKategoriler> AltKategoriler { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<UrunMatchKategori> UrunMatchKategori { get; set; }
        public DbSet<UrunMatchImage> UrunMatchImage { get; set; }
        public DbSet<Logolar> Logolar { get; set; }
        public DbSet<SosyalMedya> SosyalMedya { get; set; }
        public DbSet<Eposta> Eposta { get; set; }
        public DbSet<TasarimSablon> TasarimSablon { get; set; }
        public DbSet<Dosyalar> Dosyalar { get; set; }

        public DbSet<Slider> Slider { get; set; }

        public DbSet<SliderResimler> SliderResimler { get; set; }

        public DbSet<Parallax> Parallax { get; set; }

        public DbSet<Test> Test { get; set; }

        public DbSet<Uyeler> Uyeler { get; set; }

        public DbSet<Iller> Iller { get; set; }

        public DbSet<Ilceler> Ilceler { get; set; }

        public DbSet<SliderMatchUrun> SliderMatchUrun { get; set; }

        public DbSet<MusteriSiparis> MusteriSiparis { get; set; }

        public DbSet<MusteriSiparisItem> MusteriSiparisItem { get; set; }

        public DbSet<BirAltKategoriler> BirAltKategoriler { get; set; }

        public DbSet<SayfalarNew> SayfalarNew { get; set; }

        public DbSet<SayfalarNewItem> SayfalarNewItem { get; set; }

        public DbSet<SayfaNewItemMetin> SayfaNewItemMetin { get; set; }

        public DbSet<SayfaNewItemGaleri> SayfaNewItemGaleri { get; set; }

        public DbSet<SayfaNewItemSatir> SayfaNewItemSatir { get; set; }

        public DbSet<SayfaNewItemParallax> SayfaNewItemParallax { get; set; }

        public DbSet<SayfaNewItemSlider> SayfaNewItemSlider { get; set; }

        public DbSet<SayfaNewItemBaslik> SayfaNewItemBaslik { get; set; }

        public DbSet<SayfaNewItemIletisim> SayfaNewItemIletisim { get; set; }

        public DbSet<YaziKategori> YaziKategori { get; set; }

        public DbSet<SayfaNewItemYazi> SayfaNewItemYazi { get; set; }

        public DbSet<Yazi> Yazi { get; set; }

        public DbSet<SlideShow> SlideShow { get; set; }

        public DbSet<SayfaNewItemMetinIkili> SayfaNewItemMetinIkili { get; set; }

        public DbSet<Popup> Popup { get; set; }

        public DbSet<Siparis> Siparis { get; set; }

        public DbSet<SayfaNewItemZiyaretciYorumlari> SayfaNewItemZiyaretciYorumlari { get; set; }

        public DbSet<Login> Login { get; set; }

        public DbSet<TasarimSablonOzellik> TasarimSablonOzellik { get; set; }

        public DbSet<SolMenu> SolMenu { get; set; }

        public DbSet<AltSolMenuler> AltSolMenuler { get; set; }

        public DbSet<SiteRenkleri> SiteRenkleri { get; set; }

        public DbSet<SolMenuGrup> SolMenuGrup { get; set; }

        public DbSet<BirAltSolMenuler> BirAltSolMenuler { get; set; }

        public DbSet<SayfaReklam> SayfaReklam { get; set; }

        public DbSet<SayfaNewItemDosyaYukle> SayfaNewItemDosyaYukle { get; set; }

        public DbSet<MailKisiListesi> MailKisiListesi { get; set; }

        public DbSet<SayfaNewItemZiyaretciYorumlariMedya> SayfaNewItemZiyaretciYorumlariMedya { get; set; }

        public DbSet<SayfalarNewItemPersonel> SayfalarNewItemPersonel { get; set; }

        public DbSet<UrunMatchBeden> UrunMatchBeden { get; set; }

        public DbSet<Beden> Beden { get; set; }

        public DbSet<SayfaNewItemTab> SayfaNewItemTab { get; set; }

        public DbSet<SayfaNewItemTabItem> SayfaNewItemTabItem { get; set; }

        public DbSet<SayfaNewItemTabMetin> SayfaNewItemTabMetin { get; set; }

        public DbSet<SayfaNewItemTabGaleri> SayfaNewItemTabGaleri { get; set; }

        public DbSet<UrunTab> UrunTab { get; set; }

        public DbSet<UrunTabMetin> UrunTabMetin { get; set; }

        public DbSet<UrunResimTab> UrunResimTab { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<ContextDataModel>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
