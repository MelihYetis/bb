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
    public class TasarimSablonRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public TasarimSablonRepository(ContextDataModel dbContext)
        {
            if (dbContext == null) throw new NullReferenceException("dbContext");
            _context = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Insert(T Entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            _dbSet.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object EntityId)
        {
            throw new NotImplementedException();
        }

        public void Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public void Save(T Entity)
        {
            throw new NotImplementedException();
        }

        public void TasarimSablocSec(TasarimSablon tasarimSablon)
        {
            EskiTasarimUpdate(tasarimSablon.SablonSecimi);
            var yeniBanner = new TasarimSablon { SablonId = tasarimSablon.SablonId, SablonAdi = tasarimSablon.SablonAdi, SablonSecimi = 1 };
            using (var d = new ContextDataModel())
            {
                _context.TasarimSablon.Attach(yeniBanner);
                _context.Entry(yeniBanner).Property(y => y.SablonSecimi).IsModified = true;



                _context.SaveChanges();
            }
        }

        public void EskiTasarimUpdate(int SablonSecimi)
        {
            var query = (from e in _context.TasarimSablon where e.SablonSecimi == 1 select e).FirstOrDefault();
            SablonSecimi = 0;
            TasarimSablon eskiTasari = new TasarimSablon()
            {
                SablonId = query.SablonId,
                SablonAdi = query.SablonAdi,
                SablonSecimi = SablonSecimi
            };

            using (var g = new ContextDataModel())
            {
                ContextDataModel db = new ContextDataModel();
                db.TasarimSablon.Attach(eskiTasari);
                db.Entry(eskiTasari).Property(x => x.SablonSecimi).IsModified = true;
                db.SaveChanges();

            }



        }
    }
}
