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
    public  class YaziKategoriRepository <T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public YaziKategoriRepository(ContextDataModel dbContext)
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

        public void yaziGuncelleResimsiz(Yazi yaziModel)
        {
            ContextDataModel bd = new ContextDataModel();

            using (var db = new ContextDataModel())
            {
                db.Yazi.Attach(yaziModel);
                db.Entry(yaziModel).Property(x => x.YaziAciklama).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziBaslik).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziKategoriId).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziSeoLink).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziKisaAciklama).IsModified = true;

                db.SaveChanges();

            }
        }

        public void yaziGuncelleResimli(Yazi yaziModel)
        {
            ContextDataModel bd = new ContextDataModel();

            using (var db = new ContextDataModel())
            {
                db.Yazi.Attach(yaziModel);
                db.Entry(yaziModel).Property(x => x.YaziAciklama).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziBaslik).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziKategoriId).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziSeoLink).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziImagePath).IsModified = true;
                db.Entry(yaziModel).Property(x => x.YaziKisaAciklama).IsModified = true;


                db.SaveChanges();

            }
        }
    }
}
