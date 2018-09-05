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
    public class UstKategoriRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public UstKategoriRepository(ContextDataModel dbContext)
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

        public UstKategoriler EditUstKategori(int UstKategoriId)
        {
            var query = (from uk in _context.UstKategoriler where uk.UstKategoriId == UstKategoriId select uk).FirstOrDefault();
            return query;
        }

        public int UstKategoriCount()
        {
            var query = (from i in _context.UstKategoriler select i).Count();
            return query;
        }

        public int UstKategoriSiraBul(int UstKategoriId)
        {
            var query = (from m in _context.UstKategoriler
                         where m.UstKategoriId == UstKategoriId
                         select new { m.SiraNo }).FirstOrDefault();
            int menuSiraNo = query.SiraNo;
            return menuSiraNo;
        }
        public int AltKategoriSilVarmi(int UstKategoriId)
        {
            var altkategori = (from a in _context.AltKategoriler where a.UstKategoriId == UstKategoriId select a).ToList();
            return altkategori.Count();
        }

        public int BirAltKategoriSilVarmi(int BirAltKategoriId)
        {
            var biraltkategori = (from a in _context.BirAltKategoriler where a.BirAltKategoriId == BirAltKategoriId select a).ToList();
            return biraltkategori.Count();
        }

        public void UstKategoriSiraNoGuncelleDigerMenuYukari(int SiraNo)
        {
            SiraNo = SiraNo - 1;
            var query = (from l in _context.UstKategoriler where l.SiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo + 1;
            UstKategoriler kategorisira = new UstKategoriler()
            {
                UstKategoriId = query.UstKategoriId,
                SiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.UstKategoriler.Attach(kategorisira);
            db.Entry(kategorisira).Property(x => x.SiraNo).IsModified = true;
            db.SaveChanges();

        }
        public void UstKategoriSiraNoGuncelleDigerMenuAsagi(int SiraNo)
        {
            SiraNo = SiraNo + 1;
            var query = (from l in _context.UstKategoriler where l.SiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            UstKategoriler kategorisira = new UstKategoriler()
            {
                UstKategoriId = query.UstKategoriId,
                SiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.UstKategoriler.Attach(kategorisira);
            db.Entry(kategorisira).Property(x => x.SiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void UstKategoriSiraNoGuncelleDeleteIsleminde(int SiraNo)
        {
            var query = (from l in _context.UstKategoriler where l.SiraNo == SiraNo select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            UstKategoriler kategorisira = new UstKategoriler()
            {
                UstKategoriId = query.UstKategoriId,
                SiraNo = SiraNo
            };
            ContextDataModel db = new ContextDataModel();
            db.UstKategoriler.Attach(kategorisira);
            db.Entry(kategorisira).Property(x => x.SiraNo).IsModified = true;
            db.SaveChanges();

        }
        public void UstKategoriSiraNoGuncelle(UstKategoriler ustkategoriler)
        {

            using (var db = new ContextDataModel())
            {
                db.UstKategoriler.Attach(ustkategoriler);
                db.Entry(ustkategoriler).Property(x => x.SiraNo).IsModified = true;


                db.SaveChanges();

            }
        }
    }
}
