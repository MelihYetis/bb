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
    public class MenuRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public MenuRepository(ContextDataModel dbContext)
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

        public IList<Menuler> Menuler()
        {
            var query = (from s in _context.Menuler.OrderBy(m=>m.MenuSiraNo)

                         
                         select s).ToList();

            return query;

        }

        public int MenuCount ()
        {
            var query = (from i in _context.Menuler select i).Count();
            return query;
        }

        public int AltMenuCount(int MenuId)
        {
            var query = (from i in _context.AltMenuler where i.MenuId == MenuId select i).Count();
            return query;
        }

        public int BirAltMenuCount(int AltMenuId)
        {
            var query = (from i in _context.BirAltMenuler where i.AltMenuId == AltMenuId select i).Count();
            return query;
        }
        public int MenuSiraBul (int MenuId)
        {
            var query = (from m in _context.Menuler
                         where m.MenuId == MenuId
                         select new { m.MenuSiraNo }).FirstOrDefault();
            int menuSiraNo = query.MenuSiraNo;
            return menuSiraNo;
        }

        public void MenuSiraNoGuncelleDigerMenuYukari(int SiraNo)
        {
            SiraNo = SiraNo - 1;
            var query=(from l in _context.Menuler where l.MenuSiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo + 1;
            Menuler menu = new Menuler()
            {
                MenuAdi = query.MenuAdi,
                MenuId = query.MenuId,
                MenuSiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.Menuler.Attach(menu);
            db.Entry(menu).Property(x => x.MenuSiraNo).IsModified = true;
            db.SaveChanges();
            
        }

        public void MenuSiraNoGuncelleDigerMenuAsagi(int SiraNo)
        {
            SiraNo = SiraNo + 1;
            var query = (from l in _context.Menuler where l.MenuSiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            Menuler menu = new Menuler()
            {
                MenuAdi = query.MenuAdi,
                MenuId = query.MenuId,
                MenuSiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.Menuler.Attach(menu);
            db.Entry(menu).Property(x => x.MenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void MenuSiraNoGuncelleDeleteIsleminde(int SiraNo)
        {
            
            var query = (from l in _context.Menuler where l.MenuSiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            Menuler menu = new Menuler()
            {
                MenuAdi = query.MenuAdi,
                MenuId = query.MenuId,
                MenuSiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.Menuler.Attach(menu);
            db.Entry(menu).Property(x => x.MenuSiraNo).IsModified = true;
            db.SaveChanges();

        }
        public void MenuSiraNoGuncelle (Menuler menu)
        {
            
            using (var db = new ContextDataModel())
            {
                db.Menuler.Attach(menu);
                db.Entry(menu).Property(x => x.MenuSiraNo).IsModified = true;
                

                db.SaveChanges();

            }
        }

        public IList<AltMenuler> AltMenuler(int MenuId)
        {
            var query = (from s in _context.AltMenuler.OrderBy(m => m.MenuId).ThenBy(x => x.AltMenuSiraNo)
                         where s.MenuId == MenuId 


                         select s).ToList();

            return query;

        }
        public AltMenuler AltMenuSiraBul(int AltMenuId)
        {
            var query = (from m in _context.Menuler 
                         join n in _context.AltMenuler 
                         on m.MenuId equals n.MenuId
                         where n.AltMenuId == AltMenuId
                         select new { n.AltMenuSiraNo,m.MenuId }).FirstOrDefault();
            AltMenuler alt = new AltMenuler
            {
                AltMenuSiraNo = query.AltMenuSiraNo,
                MenuId = query.MenuId
            };
            
            return alt;
        }

        public BirAltMenuler BirAltMenuSiraBul(int BirAltMenuId)
        {
            var query = (from m in _context.Menuler
                         join n in _context.AltMenuler

                         on m.MenuId equals n.MenuId
                         from biralt in _context.BirAltMenuler
                         where biralt.MenuId == m.MenuId && biralt.AltMenuId == n.AltMenuId && biralt.BirAltMenuId == BirAltMenuId


                         select new { biralt.BirAltMenuSiraNo, biralt.AltMenuId, biralt.MenuId,biralt.BirAltMenuId }).First();
            BirAltMenuler alt = new BirAltMenuler
            {
                BirAltMenuSiraNo = query.BirAltMenuSiraNo,
                MenuId = query.MenuId,
                AltMenuId = query.AltMenuId,
                BirAltMenuId = query.BirAltMenuId
            };

            return alt;
        }

        public void AltMenuSiraNoGuncelleDigerMenuYukari(int SiraNo,int MenuId)
        {
            SiraNo = SiraNo - 1;
            var query = (from l in _context.AltMenuler where l.AltMenuSiraNo== SiraNo && l.MenuId==MenuId select l).FirstOrDefault();
            SiraNo = SiraNo + 1;
            AltMenuler menu = new AltMenuler()
            {
                AltMenuAdi = query.AltMenuAdi,
                MenuId = query.MenuId,
                AltMenuSiraNo = SiraNo,
                AltMenuId = query.AltMenuId
                
            };
            ContextDataModel db = new ContextDataModel();
            db.AltMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.AltMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void BirAltMenuSiraNoGuncelleDigerMenuYukari(int SiraNo, int MenuId,int AltMenuId)
        {
            SiraNo = SiraNo - 1;
            var query = (from l in _context.BirAltMenuler where l.BirAltMenuSiraNo == SiraNo && l.MenuId == MenuId && l.AltMenuId == AltMenuId select l).FirstOrDefault();
            SiraNo = SiraNo + 1;
            BirAltMenuler menu = new BirAltMenuler()
            {
                BirAltMenuAdi = query.BirAltMenuAdi,
                MenuId = query.MenuId,
                BirAltMenuSiraNo = SiraNo,
                AltMenuId = query.AltMenuId,
                BirAltMenuId = query.BirAltMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.BirAltMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.BirAltMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void AltMenuSiraNoGuncelleDigerMenuAsagi(int SiraNo,int MenuId)
        {
            SiraNo = SiraNo + 1;
            var query = (from l in _context.AltMenuler where l.AltMenuSiraNo == SiraNo && l.MenuId == MenuId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            AltMenuler menu = new AltMenuler()
            {
                AltMenuAdi = query.AltMenuAdi,
                MenuId = query.MenuId,
                AltMenuSiraNo = SiraNo,
                AltMenuId = query.AltMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.AltMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.AltMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void BirAltMenuSiraNoGuncelleDigerMenuAsagi(int SiraNo, int MenuId,int AltMenuId)
        {
            SiraNo = SiraNo + 1;
            var query = (from l in _context.BirAltMenuler where l.BirAltMenuSiraNo == SiraNo && l.MenuId == MenuId && l.AltMenuId == AltMenuId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            BirAltMenuler menu = new BirAltMenuler()
            {
                BirAltMenuAdi = query.BirAltMenuAdi,
                MenuId = query.MenuId,
                BirAltMenuSiraNo = SiraNo,
                BirAltMenuId = query.BirAltMenuId,
                AltMenuId = query.AltMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.BirAltMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.BirAltMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void AltMenuSiraNoGuncelleDeleteIsleminde(int SiraNo, int MenuId)
        {
            
            var query = (from l in _context.AltMenuler where l.AltMenuSiraNo == SiraNo && l.MenuId == MenuId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            AltMenuler menu = new AltMenuler()
            {
                AltMenuAdi = query.AltMenuAdi,
                MenuId = query.MenuId,
                AltMenuSiraNo = SiraNo,
                AltMenuId = query.AltMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.AltMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.AltMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void BirAltMenuSiraNoGuncelleDeleteIsleminde(int SiraNo, int MenuId,int AltMenuId)
        {

            var query = (from l in _context.BirAltMenuler where l.BirAltMenuSiraNo == SiraNo && l.MenuId == MenuId && l.AltMenuId == AltMenuId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            BirAltMenuler menu = new BirAltMenuler()
            {
                BirAltMenuAdi = query.BirAltMenuAdi,
                MenuId = query.MenuId,
                BirAltMenuSiraNo = SiraNo,
                AltMenuId = query.AltMenuId,
                BirAltMenuId = query.BirAltMenuId

            };
            ContextDataModel db = new ContextDataModel();
            db.BirAltMenuler.Attach(menu);
            db.Entry(menu).Property(x => x.BirAltMenuSiraNo).IsModified = true;
            db.SaveChanges();

        }
        public void MenuSiraNoGuncelle(AltMenuler menu)
        {

            using (var db = new ContextDataModel())
            {
                db.AltMenuler.Attach(menu);
                db.Entry(menu).Property(x => x.AltMenuSiraNo).IsModified = true;


                db.SaveChanges();

            }
        }

        public void BirMenuSiraNoGuncelle(BirAltMenuler menu)
        {

            using (var db = new ContextDataModel())
            {
                db.BirAltMenuler.Attach(menu);
                db.Entry(menu).Property(x => x.BirAltMenuSiraNo).IsModified = true;


                db.SaveChanges();

            }
        }

        public void MenuGuncelle(Menuler menu)
        {

            using (var db = new ContextDataModel())
            {
                db.Menuler.Attach(menu);
                db.Entry(menu).Property(x => x.MenuAdi).IsModified = true;
                db.Entry(menu).Property(x => x.SayfaId).IsModified = true;
                db.Entry(menu).Property(x => x.LinkAdres).IsModified = true;
                db.Entry(menu).Property(x => x.UstKategoriId).IsModified = true;
                db.Entry(menu).Property(x => x.SeoLink).IsModified = true;
                

                db.SaveChanges();

            };

        }

        public void AltMenuGuncelle(AltMenuler altmenu)
        {

            using (var db = new ContextDataModel())
            {
                db.AltMenuler.Attach(altmenu);
                db.Entry(altmenu).Property(x => x.AltMenuAdi).IsModified = true;
                db.Entry(altmenu).Property(x => x.LinkAdres).IsModified = true;
                db.Entry(altmenu).Property(x => x.MenuId).IsModified = true;
                db.Entry(altmenu).Property(x => x.UstKategoriId).IsModified = true;
                db.Entry(altmenu).Property(x => x.SayfaId).IsModified = true;
                db.Entry(altmenu).Property(x => x.SeoLink).IsModified = true;


                db.SaveChanges();

            };

        }

        public IList<BirAltMenuler> BirAltMenuler(int AltMenuId)
        {
            var query = (from s in _context.BirAltMenuler
                         where s.AltMenuId == AltMenuId


                         select s).ToList();

            return query;

        }

        public void BirAltMenuGuncelle(BirAltMenuler birAltMenu)
        {

            using (var db = new ContextDataModel())
            {
                db.BirAltMenuler.Attach(birAltMenu);
                db.Entry(birAltMenu).Property(x => x.BirAltMenuAdi).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.LinkAdres).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.MenuId).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.UstKategoriId).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.SayfaId).IsModified = true;
                db.Entry(birAltMenu).Property(x => x.SeoLink).IsModified = true;

                db.SaveChanges();

            };

        }

        public int MenuSilAltMenuVarmi(int MenuId)
        {
            var altmenu = (from altmenucount in _context.AltMenuler where altmenucount.MenuId == MenuId select altmenucount).ToList();
            return altmenu.Count();
        }

        public int AltMenuSilBirAltMenuVarmi(int AltMenuId)
        {
            var biraltmenu = (from biraltmenucount in _context.BirAltMenuler where biraltmenucount.AltMenuId == AltMenuId select biraltmenucount).ToList();
            return biraltmenu.Count();
        }

        public void MenuSayfaLinkGuncelleSayfaNewItem(Menuler menu)
        {
            using(var db = new ContextDataModel())
            {
                db.Menuler.Attach(menu);
                db.Entry(menu).Property(x => x.SayfaId).IsModified = true;

                db.SaveChanges();
            }
        }

        public void AltMenuSayfaLinkGuncelleSayfaNewItem(AltMenuler altMenu)
        {
            using(var db = new ContextDataModel())
            {
                db.AltMenuler.Attach(altMenu);
                db.Entry(altMenu).Property(x => x.SayfaId).IsModified = true;
                db.SaveChanges();
            }
        }

        public void BirAltMenuSayfaLinkGuncelleSayfaNewItem(BirAltMenuler birAltMenu)
        {
            using(var db = new ContextDataModel())
            {
                db.BirAltMenuler.Attach(birAltMenu);
                db.Entry(birAltMenu).Property(x => x.SayfaId).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}
