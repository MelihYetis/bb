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
    public class LogoRepository<T> : ImyReposiory<T> where T : class
    {
        private ContextDataModel db;

        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public LogoRepository(ContextDataModel dbContext)
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

        public Logolar Logo(int LogoId)
        {
            var query = (from l in _context.Logolar select l).FirstOrDefault();
            return query;
        }

        public void UpdateLogo(Logolar logo)
        {
            var yenilogo = new Logolar { LogoImageByte = logo.LogoImageByte, LogoId = logo.LogoId };
            using (var d = new ContextDataModel())
            {
                _context.Logolar.Attach(yenilogo);
                _context.Entry(yenilogo).Property(y => y.LogoImageByte).IsModified = true;

                _context.SaveChanges();
            }
        }
    }
}
