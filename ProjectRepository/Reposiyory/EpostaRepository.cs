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
    public class EpostaRepository<T> : ImyReposiory<T> where T : class
    {

        private ContextDataModel db;

        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public EpostaRepository(ContextDataModel dbContext)
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

        public Eposta Eposta()
        {
            var query = (from e in _context.Eposta select e).FirstOrDefault();
            return query;
        }
    }
}
