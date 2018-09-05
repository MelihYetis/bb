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
    public class MusteriSiparisRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public MusteriSiparisRepository(ContextDataModel dbContext)
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

        public void SiparismGuncelle(int MusteriSiparisId,int MusteriSiparisDurumu)
        {
            ContextDataModel bd = new ContextDataModel();
            int siparisId = Convert.ToInt32(MusteriSiparisId.ToString());
            var musteriSiparis = (from s in _context.MusteriSiparis where s.MusteriSiparisId == siparisId select s).FirstOrDefault();
            
                
            
            MusteriSiparis guncelleSiparis = new MusteriSiparis
            {
                MusteriSiparisId = musteriSiparis.MusteriSiparisId,
                SiparisDurum = MusteriSiparisDurumu

            };
            using (var db = new ContextDataModel())
            {
                db.MusteriSiparis.Attach(guncelleSiparis);
                db.Entry(guncelleSiparis).Property(x => x.SiparisDurum).IsModified = true;

                db.SaveChanges();

            }

            }
            
        }
    
}
