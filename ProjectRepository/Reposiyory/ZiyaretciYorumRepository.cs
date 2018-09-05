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
    public class ZiyaretciYorumRepository<T> : ImyReposiory<T> where T : class
    {
        private ContextDataModel db;

        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public ZiyaretciYorumRepository(ContextDataModel dbContext)
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

        public void ZiyaretciYorumOnay(int ZiyaretciYorumId)
        {


            var query = (from a in _context.SayfaNewItemZiyaretciYorumlari where a.SayfaNewItemZiyaretciYorumlariId == ZiyaretciYorumId select a).FirstOrDefault();
            SayfaNewItemZiyaretciYorumlari yorum = new SayfaNewItemZiyaretciYorumlari();
            if (query.SayfaNewItemZiyaretciYorumlariOnay == true)
            {

                yorum.SayfaNewItemZiyaretciYorumlariId = query.SayfaNewItemZiyaretciYorumlariId;
                yorum.SayfaNewItemZiyaretciYorumlariOnay = false;
            }
            else
            {
                yorum.SayfaNewItemZiyaretciYorumlariId = query.SayfaNewItemZiyaretciYorumlariId;
                yorum.SayfaNewItemZiyaretciYorumlariOnay = true;
            }

            ContextDataModel db = new ContextDataModel();
            db.SayfaNewItemZiyaretciYorumlari.Attach(yorum);
            db.Entry(yorum).Property(x => x.SayfaNewItemZiyaretciYorumlariOnay).IsModified = true;
            db.SaveChanges();
        }

        public void ResimOnay (int ResimId)
        {
            var query = (from a in _context.SayfaNewItemZiyaretciYorumlariMedya where a.SayfaNewItemZiyaretciYorumlariMedyaId == ResimId select a).FirstOrDefault();
            SayfaNewItemZiyaretciYorumlariMedya resim = new SayfaNewItemZiyaretciYorumlariMedya();
            ContextDataModel db = new ContextDataModel();

            if (query.SayfaNewItemZiyaretciResimOnay == true)
            {
                resim.SayfaNewItemZiyaretciYorumlariMedyaId = ResimId;
                resim.SayfaNewItemZiyaretciResimOnay = false;
            }

            else
            {
                resim.SayfaNewItemZiyaretciYorumlariMedyaId = ResimId;
                resim.SayfaNewItemZiyaretciResimOnay = true;
            }

            db.SayfaNewItemZiyaretciYorumlariMedya.Attach(resim);
            db.Entry(resim).Property(x => x.SayfaNewItemZiyaretciResimOnay).IsModified = true;
            db.SaveChanges();
        }
    }
}
