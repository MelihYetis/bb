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
    public class AltKategoriRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public AltKategoriRepository(ContextDataModel dbContext)
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

        public ViewModelInterWeb EditAltKategori(int AltKategoriId)
        {
            var query = (from m in _context.UstKategoriler
                         join y in _context.AltKategoriler
                         on m.UstKategoriId equals y.UstKategoriId
                         where y.AltKategoriId == AltKategoriId
                         select new { m.UstKategoriAdi, y.AltKategoriAdi, y.AltKategoriId, m.UstKategoriId }).FirstOrDefault();

            ViewModelInterWeb viewModel = new ViewModelInterWeb()
            {
                UstKategoriAdi = query.UstKategoriAdi,
                AltKategoriAdi = query.AltKategoriAdi,
                AltKategoriId = query.AltKategoriId,
                UstKategoriId = query.UstKategoriId
            };

            return viewModel;
        }

        public int AltKategoriSilBirAltKategoriVarmi(int AltKategoriId)
        {
            var biraltmenu = (from a in _context.BirAltKategoriler where a.AltKategoriId == AltKategoriId select a).ToList();
            return biraltmenu.Count();
        }

        public int UstKategoriBul(int UstKategoriId)
        {
            var query = (from u in _context.AltKategoriler
                         where u.AltKategoriId == UstKategoriId
                         select new { u.UstKategoriId }).FirstOrDefault();

            int id = query.UstKategoriId;


            return id;

        }
        public int AltKategoriCount()
        {
            var query = (from i in _context.AltKategoriler select i).Count();
            return query;
        }
        public AltKategoriler AltKategoriSiraBul(int AltKategoriId)
        {
            var query = (from m in _context.AltKategoriler
                         join n in _context.AltKategoriler
                         on m.UstKategoriId equals n.UstKategoriId
                         where n.AltKategoriId == AltKategoriId
                         select new { n.SiraNo, m.UstKategoriId }).FirstOrDefault();
            AltKategoriler alt = new AltKategoriler
            {
                SiraNo = query.SiraNo,
                UstKategoriId = query.UstKategoriId
            };

            return alt;
        }
        public void AltKategoriSiraNoGuncelle(AltKategoriler altkategoriler)
        {

            using (var db = new ContextDataModel())
            {
                db.AltKategoriler.Attach(altkategoriler);
                db.Entry(altkategoriler).Property(x => x.SiraNo).IsModified = true;


                db.SaveChanges();

            }
        }
        public void AltKAtegoriSiraNoGuncelleDeleteIsleminde(int SiraNo, int UstKategoriId)
        {

            var query = (from l in _context.AltKategoriler where l.SiraNo == SiraNo && l.UstKategoriId == UstKategoriId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            AltKategoriler kategoriler = new AltKategoriler()
            {
                UstKategoriId = query.UstKategoriId,
                SiraNo = SiraNo,
                AltKategoriId = query.AltKategoriId

            };
            ContextDataModel db = new ContextDataModel();
            db.AltKategoriler.Attach(kategoriler);
            db.Entry(kategoriler).Property(x => x.SiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void AltKategoriSiraNoGuncelleAsagi(int SiraNo, int UstKategoriId)
        {
            SiraNo = SiraNo + 1;
            var query = (from l in _context.AltKategoriler where l.SiraNo == SiraNo && l.UstKategoriId == UstKategoriId select l).FirstOrDefault();
            SiraNo = SiraNo - 1;
            AltKategoriler kategoriler = new AltKategoriler()
            {
                UstKategoriId = query.UstKategoriId,
                SiraNo = SiraNo,
                AltKategoriId = query.AltKategoriId

            };
            ContextDataModel db = new ContextDataModel();
            db.AltKategoriler.Attach(kategoriler);
            db.Entry(kategoriler).Property(x => x.SiraNo).IsModified = true;
            db.SaveChanges();

        }

        public void AltKategoriSiraNoGuncelleYukari(int SiraNo, int UstKategoriId)
        {
            SiraNo = SiraNo - 1;
            var query = (from l in _context.AltKategoriler where l.SiraNo == SiraNo && l.UstKategoriId == UstKategoriId select l).FirstOrDefault();
            SiraNo = SiraNo + 1;
            AltKategoriler kategoriler = new AltKategoriler()
            {
                UstKategoriId = query.UstKategoriId,
                SiraNo = SiraNo,
                AltKategoriId = query.AltKategoriId

            };
            ContextDataModel db = new ContextDataModel();
            db.AltKategoriler.Attach(kategoriler);
            db.Entry(kategoriler).Property(x => x.SiraNo).IsModified = true;
            db.SaveChanges();

        }
    }
}
