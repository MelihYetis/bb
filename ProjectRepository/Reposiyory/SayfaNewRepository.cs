using ProjectModel.Context;
using ProjectModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository.Reposiyory
{
    public class SayfaNewRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public SayfaNewRepository(ContextDataModel dbContext)
        {
            if (dbContext == null) throw new NullReferenceException("dbContext");
            _context = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Insert(T Entity)
        {
            _dbSet.Add(Entity);
            _context.SaveChanges();
        }

        public void Update(T Entity)
        {
            _dbSet.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object EntityId)
        {
            T entityToDelete = _dbSet.Find(EntityId);
            Delete(entityToDelete);
            Save(entityToDelete);
        }

        public void Delete(T Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached) //Concurrency için 
            {
                _dbSet.Attach(Entity);
            }
            _dbSet.Remove(Entity);
        }

        public void Save(T Entity)
        {
            _context.SaveChanges();
        }


        public IEnumerable<T> Liste()
        {
            ContextDataModel db = new ContextDataModel();
            return _context.Set<T>().ToList();
        }

        public void sayfaItemBaslikUpdate(SayfalarNewItem sayfaItem)
        {
            ContextDataModel bd = new ContextDataModel();
            
            using (var db = new ContextDataModel())
            {
                db.SayfalarNewItem.Attach(sayfaItem);
                db.Entry(sayfaItem).Property(x => x.SayfaNewItemBaslik).IsModified = true;
                
               
                db.SaveChanges();

            }
        }
        public void sayfaNewSeoGuncelle(SayfalarNew sayfaItem)
        {
            ContextDataModel bd = new ContextDataModel();

            using (var db = new ContextDataModel())
            {
                db.SayfalarNew.Attach(sayfaItem);
                db.Entry(sayfaItem).Property(x => x.SayfaNewMetaTitle).IsModified = true;
                db.Entry(sayfaItem).Property(x => x.SayfaNewMetaDescription).IsModified = true;
                db.SaveChanges();

            }
        }
        public void sayfaSolMenuUpdate(SayfalarNew sayfaNew)
        {
            ContextDataModel bd = new ContextDataModel();

            using (var db = new ContextDataModel())
            {
                db.SayfalarNew.Attach(sayfaNew);
                db.Entry(sayfaNew).Property(x => x.SolMenuGrupId).IsModified = true;


                db.SaveChanges();

            }
        }

        public void sayfaItemMetinSayfaUpdate(SayfaNewItemMetin sayfaMetinItem)
        {
            ContextDataModel bd = new ContextDataModel();

            using (var db = new ContextDataModel())
            {
                db.SayfaNewItemMetin.Attach(sayfaMetinItem);
                db.Entry(sayfaMetinItem).Property(x => x.SayfaNewItemMetinAciklama).IsModified = true;


                db.SaveChanges();

            }
        }

        public void sayfaItemMetinIkiliSayfaUpdate(SayfaNewItemMetinIkili sayfaMetinItem)
        {
            ContextDataModel bd = new ContextDataModel();

            using (var db = new ContextDataModel())
            {
                db.SayfaNewItemMetinIkili.Attach(sayfaMetinItem);
                db.Entry(sayfaMetinItem).Property(x => x.SayfaNewItemMetinIkiliAciklamaBir).IsModified = true;
                db.Entry(sayfaMetinItem).Property(x => x.SayfaNewItemMetinIkiliAciklamaIki).IsModified = true;


                db.SaveChanges();

            }
        }

        public void onSayfaUpdate(SayfalarNew sayfaModel)
        {
            var beforeOnsayfa = (from a in _context.SayfalarNew where a.SayfaNewOnSayfa == 1 select a).FirstOrDefault();
            if (beforeOnsayfa != null)
            {
                beforeOnsayfa.SayfaNewOnSayfa = 0;
                ContextDataModel bd = new ContextDataModel();

                using (var db = new ContextDataModel())
                {
                    db.SayfalarNew.Attach(beforeOnsayfa);
                    db.Entry(beforeOnsayfa).Property(x => x.SayfaNewOnSayfa).IsModified = true;
                    db.SaveChanges();
                }
            }
           
            var afterOnsayfa = (from b in _context.SayfalarNew where b.SayfaNewId == sayfaModel.SayfaNewId select b).FirstOrDefault();
            afterOnsayfa.SayfaNewOnSayfa = 1;
            using (var db = new ContextDataModel())
            {
                db.SayfalarNew.Attach(afterOnsayfa);
                db.Entry(afterOnsayfa).Property(x => x.SayfaNewOnSayfa).IsModified = true;
                db.SaveChanges();
            }
        }

        public void GaleriItemResimGuncelle(SayfaNewItemGaleri img)
        {
            ContextDataModel bd = new ContextDataModel();

            var resimler = new SayfaNewItemGaleri { SayfaNewItemGaleriId = img.SayfaNewItemGaleriId, SayfalarNewItemResimAciklama = img.SayfalarNewItemResimAciklama, SayfalarNewItemResimPath = img.SayfalarNewItemResimPath };
            using (var db = new ContextDataModel())
            {
                db.SayfaNewItemGaleri.Attach(resimler);
                db.Entry(resimler).Property(x => x.SayfalarNewItemResimPath).IsModified = true;
                db.Entry(resimler).Property(x => x.SayfalarNewItemResimAciklama).IsModified = true;

                db.SaveChanges();

            }
        }

        public void GaleriResimYaziGuncelle(SayfaNewItemGaleri img)
        {
            ContextDataModel bd = new ContextDataModel();

            var resimler = new SayfaNewItemGaleri { SayfaNewItemGaleriId = img.SayfaNewItemGaleriId, SayfalarNewItemResimAciklama = img.SayfalarNewItemResimAciklama, SayfalarNewItemResimPath = img.SayfalarNewItemResimPath };
            using (var db = new ContextDataModel())
            {
                db.SayfaNewItemGaleri.Attach(resimler);

                db.Entry(resimler).Property(x => x.SayfalarNewItemResimAciklama).IsModified = true;

                db.SaveChanges();

            }
        }

        public SayfalarNewItem SayfaItemSiraBul(int SayfalarNewItem)
        {
            var query = (from m in _context.SayfalarNew
                         join n in _context.SayfalarNewItem
                         on m.SayfaNewId equals n.SayfaNewId
                         where n.SayfalarNewItemId == SayfalarNewItem
                         select new { n.SayfaItemSiraNo, m.SayfaNewId,n.SayfalarNewItemId }).FirstOrDefault();
            SayfalarNewItem alt = new SayfalarNewItem
            {
                SayfaItemSiraNo = query.SayfaItemSiraNo,
                SayfaNewId = query.SayfaNewId,
                SayfalarNewItemId = query.SayfalarNewItemId
                
            };

            return alt;
        }

        public void SayfaItemSiraNoGuncelleDigerMenuYukari(int SiraNo, int MenuId)
        {
            SiraNo = SiraNo - 1;
            var query = (from l in _context.SayfalarNewItem where l.SayfaItemSiraNo == SiraNo && l.SayfaNewId == MenuId select l).FirstOrDefault();
            SiraNo = SiraNo + 1;
            SayfalarNewItem menu = new SayfalarNewItem()
            {
                SayfaNewItemBaslik = query.SayfaNewItemBaslik,
                SayfaNewId = query.SayfaNewId,
                SayfaItemSiraNo = SiraNo,
                SayfalarNewItemId = query.SayfalarNewItemId
                
            };
            ContextDataModel db = new ContextDataModel();
            db.SayfalarNewItem.Attach(menu);
            db.Entry(menu).Property(x => x.SayfaItemSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void SayfaItemSiraNoGuncelle(SayfalarNewItem menu)
        {

            using (var db = new ContextDataModel())
            {
                db.SayfalarNewItem.Attach(menu);
                db.Entry(menu).Property(x => x.SayfaItemSiraNo).IsModified = true;


                db.SaveChanges();

            }
        }

        public void SayfaItemSiraNoGuncelleDigerMenuAsagi(int SiraNo, int MenuId)
        {
            SiraNo = SiraNo + 1;
            var query = (from l in _context.SayfalarNewItem where l.SayfaItemSiraNo == SiraNo && l.SayfaNewId == MenuId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            SayfalarNewItem menu = new SayfalarNewItem()
            {
                SayfaNewItemBaslik = query.SayfaNewItemBaslik,
                SayfaNewId = query.SayfaNewId,
                SayfaItemSiraNo = SiraNo,
                SayfalarNewItemId = query.SayfalarNewItemId

            };
            ContextDataModel db = new ContextDataModel();
            db.SayfalarNewItem.Attach(menu);
            db.Entry(menu).Property(x => x.SayfaItemSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public int SayfaItemCount(int ItemId)
        {
            var query = (from i in _context.SayfalarNewItem where i.SayfaNewId == ItemId select i.SayfaItemSiraNo).Count();
            return query;
        }

        public void SayfaItemSatirKolonSayisiGuncelle(SayfalarNewItem model)
        {
            ContextDataModel db = new ContextDataModel();
            db.SayfalarNewItem.Attach(model);
            db.Entry(model).Property(x => x.SayfaItemSatirKolonSayisi).IsModified = true;
            db.SaveChanges();
        }

        public void SayfaNewItemKolonGuncelle(int satirid,SayfaNewItemSatir model)
        {
            ContextDataModel db = new ContextDataModel();
            db.SayfaNewItemSatir.Attach(model);
            
        }

        public void SayfaSatirAllKolonGuncelle(SayfaNewItemSatir model)
        {
            ContextDataModel db = new ContextDataModel();
            db.SayfaNewItemSatir.Attach(model);
            db.Entry(model).Property(x => x.SayfaNewItemSatirAllKolon).IsModified = true;
            db.SaveChanges();
        }

        public void SayfaItemRenkGuncelle(SayfalarNewItem model)
        {
            ContextDataModel db = new ContextDataModel();
            db.SayfalarNewItem.Attach(model);
            db.Entry(model).Property(x => x.SayfaNewItemArkaPlanRenk).IsModified = true;
            db.SaveChanges();


        }

        public void SayfaMetaGuncelle(SayfalarNew model)
        {
            ContextDataModel db = new ContextDataModel();
            db.SayfalarNew.Attach(model);
            db.Entry(model).Property(x => x.SayfaNewMetaTitle).IsModified = true;
            db.Entry(model).Property(x => x.SayfaNewMetaDescription).IsModified = true;
            db.Entry(model).Property(x => x.SayfaNewAnahtarKelimeler).IsModified = true;
            db.SaveChanges();
        }

        public void SayfaUyeIzinGuncelle(int SayfaNewId)
        {
            

            var query = (from a in _context.SayfalarNew where a.SayfaNewId == SayfaNewId select a).FirstOrDefault();
            SayfalarNew sayfa = new SayfalarNew();
            if (query.KullaniciGirisAktifPasif == true)
            {

                sayfa.SayfaNewId = query.SayfaNewId;
                sayfa.KullaniciGirisAktifPasif = false;
            }
            else
            {
                sayfa.SayfaNewId = query.SayfaNewId;
                sayfa.KullaniciGirisAktifPasif = true;                
            }
            
            ContextDataModel db = new ContextDataModel();
            db.SayfalarNew.Attach(sayfa);
            db.Entry(sayfa).Property(x => x.KullaniciGirisAktifPasif).IsModified = true;
            db.SaveChanges();
        }

        public void SayfaSolMenuGuncelle(int SayfaNewId)
        {


            var query = (from a in _context.SayfalarNew where a.SayfaNewId == SayfaNewId select a).FirstOrDefault();
            SayfalarNew sayfa = new SayfalarNew();
            if (query.SolMenuId == true)
            {

                sayfa.SayfaNewId = query.SayfaNewId;
                sayfa.SolMenuId = false;
            }
            else
            {
                sayfa.SayfaNewId = query.SayfaNewId;
                sayfa.SolMenuId = true;
            }

            ContextDataModel db = new ContextDataModel();
            db.SayfalarNew.Attach(sayfa);
            db.Entry(sayfa).Property(x => x.SolMenuId).IsModified = true;
            db.SaveChanges();
        }

        public void SayfaSiraNoGuncelleDeleteIsleminde(int SiraNo, int SayfaNewId)
        {

            var query = (from l in _context.SayfalarNewItem where l.SayfaItemSiraNo == SiraNo && l.SayfaNewId == SayfaNewId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;

            SayfalarNewItem sayfaItem = new SayfalarNewItem()
            {
                SayfaItemSatirKolonSayisi = query.SayfaItemSatirKolonSayisi,
                 SayfaItemSiraNo = SiraNo,
                 SayfalarNew = query.SayfalarNew,
                 SayfalarNewItemId = query.SayfalarNewItemId,
                 SayfaNewId = query.SayfaNewId,
                 SayfaNewItemArkaPlanRenk = query.SayfaNewItemArkaPlanRenk,
                 SayfaNewItemBaslik = query.SayfaNewItemBaslik,
                 SayfaNewItemTip = query.SayfaNewItemTip
            };
            
            ContextDataModel db = new ContextDataModel();
            db.SayfalarNewItem.Attach(sayfaItem);
            db.Entry(sayfaItem).Property(x => x.SayfaItemSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void SayfaBackgroundImageGuncelle(SayfalarNew model)
        {
            ContextDataModel db = new ContextDataModel();
            db.SayfalarNew.Attach(model);
            db.Entry(model).Property(x => x.BackgroundImage).IsModified = true;

            db.SaveChanges();
        }

        public void SayfaNewTamIsimUpdate(SayfaNewItemTab model)
        {
            ContextDataModel bd = new ContextDataModel();

            using (var db = new ContextDataModel())
            {
                db.SayfaNewItemTab.Attach(model);
                db.Entry(model).Property(x => x.SayfaNewItemTabAdi).IsModified = true;


                db.SaveChanges();

            }
        }
    }
}
