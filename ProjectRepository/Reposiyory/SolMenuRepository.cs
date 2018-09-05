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
    public class SolMenuRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public SolMenuRepository(ContextDataModel dbContext)
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

        public int SolMenuCount()
        {
            var query = (from i in _context.SolMenu select i).Count();
            return query;
        }

        public IList<SolMenu> SolMenuler(int SolGrupId)
        {
            var query = (from s in _context.SolMenu.OrderBy(m => m.SolMenuSiraNo).Where(m => m.SolMenuGrupId == SolGrupId)


                         select s).ToList();

            return query;

        }

       
        public IList<SolMenuGrup> SolGrupMenuler()
        {
            var query = (from s in _context.SolMenuGrup.OrderBy(m => m.SolMenuGrupAdi)


                         select s).ToList();

            return query;

        }

        public void SolMenuSiraNoGuncelleDeleteIsleminde(int SiraNo)
        {

            var query = (from l in _context.SolMenu where l.SolMenuSiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            SolMenu menu = new SolMenu()
            {
                SolMenuAdi = query.SolMenuAdi,
                SolMenuId = query.SolMenuId,
                SolMenuSiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.SolMenu.Attach(menu);
            db.Entry(menu).Property(x => x.SolMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public int SolMenuSiraBul(int SolMenuId)
        {
            var query = (from m in _context.SolMenu
                         where m.SolMenuId == SolMenuId
                         select new { m.SolMenuSiraNo }).FirstOrDefault();
            int menuSiraNo = query.SolMenuSiraNo;
            return menuSiraNo;
        }

        public void SolMenuSiraNoGuncelleDigerMenuYukari(int SiraNo)
        {
            SiraNo = SiraNo - 1;
            var query = (from l in _context.SolMenu where l.SolMenuSiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo + 1;
            SolMenu menu = new SolMenu()
            {
                SolMenuAdi = query.SolMenuAdi,
                SolMenuId = query.SolMenuId,
                SolMenuSiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.SolMenu.Attach(menu);
            db.Entry(menu).Property(x => x.SolMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void SolMenuSiraNoGuncelle(SolMenu menu)
        {

            using (var db = new ContextDataModel())
            {
                db.SolMenu.Attach(menu);
                db.Entry(menu).Property(x => x.SolMenuSiraNo).IsModified = true;


                db.SaveChanges();

            }
        }

        public void SolMenuSiraNoGuncelleDigerMenuAsagi(int SiraNo)
        {
            SiraNo = SiraNo + 1;
            var query = (from l in _context.SolMenu where l.SolMenuSiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            SolMenu menu = new SolMenu()
            {
                SolMenuAdi = query.SolMenuAdi,
                SolMenuId = query.SolMenuId,
                SolMenuSiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.SolMenu.Attach(menu);
            db.Entry(menu).Property(x => x.SolMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void SolMenuGuncelle(SolMenu menu)
        {

            using (var db = new ContextDataModel())
            {
                db.SolMenu.Attach(menu);
                db.Entry(menu).Property(x => x.SolMenuAdi).IsModified = true;
                db.Entry(menu).Property(x => x.SayfaId).IsModified = true;
                db.Entry(menu).Property(x => x.LinkAdres).IsModified = true;
                db.Entry(menu).Property(x => x.UstKategoriId).IsModified = true;


                db.SaveChanges();

            };

        }

        public int AltSolMenuCount(int SolMenuId)
        {
            var query = (from i in _context.AltSolMenuler where i.SolMenuId == SolMenuId select i).Count();
            return query;
        }

        public int BirAltSolMenuCount(int SolAltMenuId)
        {
            var query = (from i in _context.BirAltSolMenuler where i.AltSolMenuId == SolAltMenuId select i).Count();
            return query;
        }

        public IList<AltSolMenuler> AltSolMenuler(int SolMenuId)
        {
            var query = (from s in _context.AltSolMenuler.OrderBy(m => m.SolMenuId).ThenBy(x => x.AltSolMenuSiraNo)
                         where s.SolMenuId == SolMenuId


                         select s).ToList();

            return query;

        }

        public IList<BirAltSolMenuler> BirAltSolMenuler(int SolAltMenuId)
        {
            var query = (from s in _context.BirAltSolMenuler.OrderBy(m => m.AltSolMenuId).ThenBy(x => x.BirAltSolMenuSiraNo)
                         where s.AltSolMenuId == SolAltMenuId


                         select s).ToList();

            return query;

        }
        public void AltSolMenuGuncelle(AltSolMenuler altmenu)
        {

            using (var db = new ContextDataModel())
            {
                db.AltSolMenuler.Attach(altmenu);
                db.Entry(altmenu).Property(x => x.AltSolMenuAdi).IsModified = true;
                db.Entry(altmenu).Property(x => x.LinkAdres).IsModified = true;
                db.Entry(altmenu).Property(x => x.SolMenuId).IsModified = true;
                db.Entry(altmenu).Property(x => x.UstKategoriId).IsModified = true;
                db.Entry(altmenu).Property(x => x.SayfaId).IsModified = true;


                db.SaveChanges();

            };

        }

        public void AltSolMenuSiraNoGuncelleDeleteIsleminde(int SiraNo, int SolMenuId)
        {

            var query = (from l in _context.AltSolMenuler where l.AltSolMenuSiraNo == SiraNo && l.SolMenuId == SolMenuId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            AltSolMenuler menu = new AltSolMenuler()
            {
                AltSolMenuAdi = query.AltSolMenuAdi,
                SolMenuId = query.SolMenuId,
                AltSolMenuSiraNo = SiraNo,
                AltSolMenuId = query.AltSolMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.AltSolMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.AltSolMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public AltSolMenuler AltSolMenuSiraBul(int AltSolMenuId)
        {
            var query = (from m in _context.SolMenu
                         join n in _context.AltSolMenuler
                         on m.SolMenuId equals n.SolMenuId
                         where n.AltSolMenuId == AltSolMenuId
                         select new { n.AltSolMenuSiraNo, m.SolMenuId }).FirstOrDefault();
            AltSolMenuler alt = new AltSolMenuler
            {
                AltSolMenuSiraNo = query.AltSolMenuSiraNo,
                SolMenuId = query.SolMenuId
            };

            return alt;
        }

        public void AltSolMenuSiraNoGuncelleDigerMenuYukari(int SiraNo, int SolMenuId)
        {
            SiraNo = SiraNo - 1;
            var query = (from l in _context.AltSolMenuler where l.AltSolMenuSiraNo == SiraNo && l.SolMenuId == SolMenuId select l).FirstOrDefault();
            SiraNo = SiraNo + 1;
            AltSolMenuler menu = new AltSolMenuler()
            {
                AltSolMenuAdi = query.AltSolMenuAdi,
                SolMenuId = query.SolMenuId,
                AltSolMenuSiraNo = SiraNo,
                AltSolMenuId = query.AltSolMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.AltSolMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.AltSolMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void SolMenuSiraNoGuncelle(AltSolMenuler menu)
        {

            using (var db = new ContextDataModel())
            {
                db.AltSolMenuler.Attach(menu);
                db.Entry(menu).Property(x => x.AltSolMenuSiraNo).IsModified = true;


                db.SaveChanges();

            }
        }

        public void SolAltMenuSiraNoGuncelleDigerMenuAsagi(int SiraNo, int SolMenuId)
        {
            SiraNo = SiraNo + 1;
            var query = (from l in _context.AltSolMenuler where l.AltSolMenuSiraNo == SiraNo && l.SolMenuId == SolMenuId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            AltSolMenuler menu = new AltSolMenuler()
            {
                AltSolMenuAdi = query.AltSolMenuAdi,
                SolMenuId = query.SolMenuId,
                AltSolMenuSiraNo = SiraNo,
                AltSolMenuId = query.AltSolMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.AltSolMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.AltSolMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void BirAltSolMenuGuncelle(BirAltSolMenuler birAltMenu)
        {

            using (var db = new ContextDataModel())
            {
                db.BirAltSolMenuler.Attach(birAltMenu);
                db.Entry(birAltMenu).Property(x => x.BirAltSolMenuAdi).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.LinkAdres).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.SolMenuId).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.UstKategoriId).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.SayfaId).IsModified = true;


                db.SaveChanges();

            };

        }

        public void BirAltSolMenuSiraNoGuncelleDeleteIsleminde(int SiraNo, int MenuId, int AltMenuId)
        {

            var query = (from l in _context.BirAltSolMenuler where l.BirAltSolMenuSiraNo == SiraNo && l.SolMenuId == MenuId && l.AltSolMenuId == AltMenuId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            BirAltSolMenuler menu = new BirAltSolMenuler()
            {
                BirAltSolMenuAdi = query.BirAltSolMenuAdi,
                SolMenuId = query.SolMenuId,
                BirAltSolMenuSiraNo = SiraNo,
                AltSolMenuId = query.AltSolMenuId,
                BirAltSolMenuId = query.BirAltSolMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.BirAltSolMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.BirAltSolMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void MenuSayfaLinkGuncelleSayfaNewItem(SolMenu menu)
        {
            using (var db = new ContextDataModel())
            {
                db.SolMenu.Attach(menu);
                db.Entry(menu).Property(x => x.SayfaId).IsModified = true;

                db.SaveChanges();
            }
        }

        public void AltMenuSayfaLinkGuncelleSayfaNewItem(AltSolMenuler altMenu)
        {
            using (var db = new ContextDataModel())
            {
                db.AltSolMenuler.Attach(altMenu);
                db.Entry(altMenu).Property(x => x.SayfaId).IsModified = true;
                db.SaveChanges();
            }
        }

        public void BirAltMenuSayfaLinkGuncelleSayfaNewItem(BirAltSolMenuler birAltMenu)
        {
            using (var db = new ContextDataModel())
            {
                db.BirAltSolMenuler.Attach(birAltMenu);
                db.Entry(birAltMenu).Property(x => x.SayfaId).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}
