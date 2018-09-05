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
    public class SayfaRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public SayfaRepository(ContextDataModel dbContext)
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

        public Sayfalar EditSayfalar (int SayfaId)
        {
            var query = (from s in _context.Sayfalar where s.SayfaId == SayfaId select s).FirstOrDefault();

            return query;
        }

        public  ViewModelInterWeb EditIletisimSayfalar(int SayfaId)
        {
            var query = (from s in _context.IletisimItem
                         join y in _context.Sayfalar on s.SayfaId equals y.SayfaId where s.SayfaId == SayfaId select 
                        new {s.SayfaId,s.IletisimAdres,s.IletisimEmail,s.IletisimFax,s.IletisimKisaAciklama,s.IletisimTel,s.IletsimItemId,
                        y.MetaTitle,y.MetaDescription,s.ProfilAdi}).FirstOrDefault();

            
            var vm = new ViewModelInterWeb() {IletisimAdres = query.IletisimAdres,IletisimFax = query.IletisimFax,IletisimEmail=query.IletisimEmail,
            IletisimKisaAciklama = query.IletisimKisaAciklama,IletisimTel=query.IletisimTel,IletsimItemId=query.IletsimItemId,
            MetaTitle=query.MetaTitle,MetaDescription=query.MetaDescription,ProfilAdi=query.ProfilAdi};
            return vm;
        }

        public ViewModelInterWeb EditHaberlerSayfalar (int SayfaId)
        {
            var query = (from s in _context.Haberler
                         join
                             m in _context.Sayfalar on s.SayfaId equals m.SayfaId
                         where s.SayfaId == SayfaId
                         select new { s.SayfaId, s.HaberAciklama, s.HaberAdi, s.HaberId, m.MetaTitle, m.MetaDescription }).FirstOrDefault();

            var vm = new ViewModelInterWeb()
            {
                HaberAciklama = query.HaberAciklama,
                HaberAdi = query.HaberAdi,
                HaberId = query.HaberId,
                SayfaId = query.SayfaId,
                MetaTitle = query.MetaTitle,
                MetaDescription = query.MetaDescription
            };

            return vm;
        }

        public List<ViewModelInterWeb> EditResimler(int SayfaId)
        {
            var query = (from s in _context.Sayfalar
                         join k in _context.Resimler on s.SayfaId equals k.SayfaId
                         where s.SayfaId == SayfaId
                         select new
                         {
                             s.AnahtarKelimeler,
                             s.DefOzl,
                             s.MetaDescription,
                             s.MetaTitle,
                             s.SabitSayfa,
                             s.SayfaAdi,
                             s.SayfaId,
                             s.SayfaSatir2Modeli,
                             s.SayfaSatir3Modeli,
                             s.SayfaSatir4Modeli,
                             s.SayfaSatirModeli,
                             s.SayfaSatirSayisi,
                             s.SayfaSutun2Sayisi,
                             s.SayfaSutun3Sayisi,
                             s.SayfaSutun4Sayisi,
                             s.SayfaSutunSayisi,
                             k.ResimImageByte,
                             k.ResimId
                         });
            List<ViewModelInterWeb> list = new List<ViewModelInterWeb>();

            foreach (var item in query)
            {
                list.Add(new ViewModelInterWeb
                {
                    AnahtarKelimeler = item.AnahtarKelimeler,
                    DefOzl = item.DefOzl,
                    MetaDescription = item.MetaDescription,
                    MetaTitle = item.MetaTitle,
                    SabitSayfa = item.SabitSayfa,
                    SayfaAdi = item.SayfaAdi,
                    SayfaId = item.SayfaId,
                    SayfaSatir2Modeli = item.SayfaSatir2Modeli,
                    SayfaSatir3Modeli = item.SayfaSatir3Modeli,
                    SayfaSatir4Modeli = item.SayfaSatir4Modeli,
                    SayfaSatirModeli = item.SayfaSatirModeli,
                    SayfaSatirSayisi = item.SayfaSatirSayisi,
                    SayfaSutun2Sayisi = item.SayfaSutun2Sayisi,
                    SayfaSutun3Sayisi = item.SayfaSutun3Sayisi,
                    SayfaSutun4Sayisi = item.SayfaSutun4Sayisi,
                    SayfaSutunSayisi = item.SayfaSutunSayisi,
                    ResimImageByte = item.ResimImageByte,
                    ResimId = item.ResimId
                });
            }

            return list;
        }

        public void IletisimGuncelle(IletisimItem Iletisim)
        {
            ContextDataModel bd = new ContextDataModel();
            var iletisimitem = new IletisimItem { IletsimItemId = Iletisim.IletsimItemId, IletisimTel= Iletisim.IletisimTel, IletisimFax = Iletisim.IletisimFax, IletisimEmail= Iletisim.IletisimEmail,IletisimAdres = Iletisim.IletisimAdres,IletisimKisaAciklama = Iletisim.IletisimKisaAciklama,IletisimGoogleMaps = Iletisim.IletisimGoogleMaps,ProfilAdi = Iletisim.ProfilAdi };
            using (var db = new ContextDataModel())
            {
                db.IletisimItem.Attach(iletisimitem);
                db.Entry(iletisimitem).Property(x => x.IletisimTel).IsModified = true;
                db.Entry(iletisimitem).Property(x => x.IletisimFax).IsModified = true;
                db.Entry(iletisimitem).Property(x => x.IletisimEmail).IsModified = true;
                db.Entry(iletisimitem).Property(x => x.IletisimAdres).IsModified = true;
                db.Entry(iletisimitem).Property(x => x.IletisimKisaAciklama).IsModified = true;
                db.Entry(iletisimitem).Property(x => x.IletisimGoogleMaps).IsModified = true;
                db.Entry(iletisimitem).Property(x => x.ProfilAdi).IsModified = true;
                db.SaveChanges();

            }
        }

        public void ResimGuncelle(Resimler img)
        {
            ContextDataModel bd = new ContextDataModel();
            
            var resimler = new Resimler {ResimId = img.ResimId, ResimAciklama=img.ResimAciklama, ResimImageByte = img.ResimImageByte,LinkAdres = img.LinkAdres,LinkSayfaId=img.LinkSayfaId};
            using (var db = new ContextDataModel())
            {
                db.Resimler.Attach(resimler);
                db.Entry(resimler).Property(x => x.ResimImageByte).IsModified = true;
                db.Entry(resimler).Property(x => x.ResimAciklama).IsModified = true;
                db.Entry(resimler).Property(x => x.LinkSayfaId).IsModified = true;
                db.Entry(resimler).Property(x => x.LinkAdres).IsModified = true;
                db.SaveChanges();
                
            }
        }

        public void ResimYaziGuncelle(Resimler img)
        {
            ContextDataModel bd = new ContextDataModel();

            var resimler = new Resimler { ResimId = img.ResimId, ResimAciklama = img.ResimAciklama, ResimImageByte = img.ResimImageByte,LinkSayfaId=img.LinkSayfaId,LinkAdres = img.LinkAdres };
            using (var db = new ContextDataModel())
            {
                db.Resimler.Attach(resimler);
                
                db.Entry(resimler).Property(x => x.ResimAciklama).IsModified = true;
                db.Entry(resimler).Property(x => x.LinkSayfaId).IsModified = true;
                db.Entry(resimler).Property(x => x.LinkAdres).IsModified = true;
                db.SaveChanges();

            }
        }

        public IList<Haberler> HaberlerList (int SayfaId)
        {
            var query = (from s in _context.Haberler

                         where s.SayfaId == SayfaId
                         select s).ToList();

            return query;
                         
        }

        public Haberler HaberItem (int HaberId)
        {
            var query = (from i in _context.Haberler where i.HaberId== HaberId select i).FirstOrDefault();
            return query;

        }

        public void MetinSayfasiEkle (int SayfaId)
        {
            SayfalarMetin Metin = new SayfalarMetin();
            Metin.SayfaId = SayfaId;
            SayfaRepository<SayfalarMetin> sayfalarMetin = new SayfaRepository<SayfalarMetin>(_context);
            sayfalarMetin.Insert(Metin);
        }

        public SayfalarMetin EditMetinSayfasi(int SayfaId)
        {
            var query = (from i in _context.SayfalarMetin where i.SayfaId == SayfaId select i).FirstOrDefault();
            return query;

        }

        public GaleriSayfaResimler GaleriSayfaResimler(int SayfaId)
        {
            var query = (from i in _context.Sayfalar where i.SayfaId == SayfaId select i).FirstOrDefault();
            var queryGaleriSayfa = new GaleriSayfaResimler
            {
                SayfaId = query.SayfaId
            };
            return queryGaleriSayfa;

        }
        public void GaleriResimGuncelle(GaleriSayfaResimler img)
        {
            ContextDataModel bd = new ContextDataModel();

            var resimler = new GaleriSayfaResimler { GaleriSayfaResimlerId = img.GaleriSayfaResimlerId, GaleriSayfaResimAciklama = img.GaleriSayfaResimAciklama, GaleriSayfaResimImageByte= img.GaleriSayfaResimImageByte};
            using (var db = new ContextDataModel())
            {
                db.GaleriSayfaResimler.Attach(resimler);
                db.Entry(resimler).Property(x => x.GaleriSayfaResimImageByte).IsModified = true;
                db.Entry(resimler).Property(x => x.GaleriSayfaResimAciklama).IsModified = true;

                db.SaveChanges();

            }
        }

        public void GaleriResimYaziGuncelle(GaleriSayfaResimler img)
        {
            ContextDataModel bd = new ContextDataModel();

            var resimler = new GaleriSayfaResimler { GaleriSayfaResimlerId = img.GaleriSayfaResimlerId, GaleriSayfaResimAciklama= img.GaleriSayfaResimAciklama, GaleriSayfaResimImageByte = img.GaleriSayfaResimImageByte};
            using (var db = new ContextDataModel())
            {
                db.GaleriSayfaResimler.Attach(resimler);

                db.Entry(resimler).Property(x => x.GaleriSayfaResimAciklama).IsModified = true;

                db.SaveChanges();

            }
        }

        public void ParalaxUpdateResimsiz(SayfaNewItemParallax model)
        {
            using(var db = new ContextDataModel())
            {
                db.SayfaNewItemParallax.Attach(model);
                db.Entry(model).Property(x => x.SayfaNewItemParallaxAciklama).IsModified = true;

                db.SaveChanges();
            }
        }

        public void PersonelUpdateResimsiz(SayfalarNewItemPersonel model)
        {
            using (var db = new ContextDataModel())
            {
                db.SayfalarNewItemPersonel.Attach(model);
                db.Entry(model).Property(x => x.SayfalarNewItemPersonelAciklama).IsModified = true;

                db.SaveChanges();
            }
        }

        public void PersonelUpdate(SayfalarNewItemPersonel model)
        {
            using (var db = new ContextDataModel())
            {
                db.SayfalarNewItemPersonel.Attach(model);
                db.Entry(model).Property(x => x.SayfalarNewItemPersonelResimPath).IsModified = true;
                db.Entry(model).Property(x => x.SayfalarNewItemPersonelAciklama).IsModified = true;

                db.SaveChanges();
            }
        }

        
    }
}
