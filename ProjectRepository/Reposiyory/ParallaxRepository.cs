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
    public class ParallaxRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }
        public ParallaxRepository(ContextDataModel dbContext)
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

        public void UpdateParallax(Parallax parallax)
        {
            if (parallax.ParallaxResimImageByte != null)
            {
                var yeniParallax = new Parallax { ParallaxResimImageByte = parallax.ParallaxResimImageByte, ParallaxId = parallax.ParallaxId,ParallaxAciklama = parallax.ParallaxAciklama,ParallaxYeri=parallax.ParallaxYeri,ParallaxAktifPasif = parallax.ParallaxAktifPasif };

                using (var d = new ContextDataModel())
                {
                    _context.Parallax.Attach(yeniParallax);
                    _context.Entry(yeniParallax).Property(y => y.ParallaxResimImageByte).IsModified = true;
                    _context.Entry(yeniParallax).Property(y => y.ParallaxAciklama).IsModified = true;
                    _context.Entry(yeniParallax).Property(y => y.ParallaxYeri).IsModified = true;
                    _context.Entry(yeniParallax).Property(y => y.ParallaxAktifPasif).IsModified = true;

                    _context.SaveChanges();
                }    
            }

            else
            {
                var yeniParallax = new Parallax { ParallaxResimImageByte = parallax.ParallaxResimImageByte, ParallaxId = parallax.ParallaxId, ParallaxAciklama = parallax.ParallaxAciklama,ParallaxYeri=parallax.ParallaxYeri,ParallaxAktifPasif = parallax.ParallaxAktifPasif };

                using (var d = new ContextDataModel())
                {
                    _context.Parallax.Attach(yeniParallax);
                    
                    _context.Entry(yeniParallax).Property(y => y.ParallaxAciklama).IsModified = true;
                    _context.Entry(yeniParallax).Property(y => y.ParallaxYeri).IsModified = true;
                    _context.Entry(yeniParallax).Property(y => y.ParallaxAktifPasif).IsModified = true;

                    _context.SaveChanges();
                }
            }
            
        }
    }
}
