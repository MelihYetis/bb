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
    public class SiteRenkRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public SiteRenkRepository(ContextDataModel dbContext)
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
            Save(Entity);
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
            _context.SaveChanges();
        }

        public void UpdateBodyRenkKodu(SiteRenkleri renk)
        {
            ContextDataModel db = new ContextDataModel();
            db.SiteRenkleri.Attach(renk);
            db.Entry(renk).Property(x => x.BodyRenkKodu).IsModified = true;
            db.SaveChanges();
        }

        public void UpdateMenuRenkKodu(SiteRenkleri renk)
        {
            ContextDataModel db = new ContextDataModel();
            db.SiteRenkleri.Attach(renk);
            db.Entry(renk).Property(x => x.MenuRenkKodu).IsModified = true;
            db.SaveChanges();
        }

        public void UpdateFooterRenkKodu(SiteRenkleri renk)
        {
            ContextDataModel db = new ContextDataModel();
            db.SiteRenkleri.Attach(renk);
            db.Entry(renk).Property(x => x.FooterRenkKodu).IsModified = true;
            db.SaveChanges();
        }
    }
}
