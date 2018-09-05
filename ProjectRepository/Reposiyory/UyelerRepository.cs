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
    public class UyelerRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public UyelerRepository(ContextDataModel dbContext)
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

        public List<Ilceler> IlcelerList(int IlId)
        {
            var ilceler = (from a in _context.Ilceler.OrderBy(s=>s.IlceAdi) where a.IlId == IlId select a).ToList();


            return ilceler;
        }

        public ViewModelUyeler editUye (int UyeId)
        {
            var query = (from u in _context.Uyeler
                         join i in _context.Iller on u.UyeSehirId equals i.IlId
                         join ilce in _context.Ilceler on u.UyeIlceId equals ilce.IlceId
                         where u.UyeId == UyeId
                         select
                             new ViewModelUyeler
                             {
                                 UyeId = u.UyeId,
                                 UyeAdi = u.UyeAdi,
                                 UyeSoyadi = u.UyeSoyadi,
                                 UyeSehirId = u.UyeSehirId,
                                 IlAdi = i.IlAdi,
                                 UyeIlceId = u.UyeIlceId,
                                 IlceAdi = ilce.IlceAdi,
                                 UyeEmail = u.UyeEmail,
                                 UyeAdres = u.UyeAdres,
                                 UyeTelNo = u.UyeTelNo,
                                 UyePassword = u.UyePassword,
                                 ReUyePassword = u.ReUyePassword,
                                 UyeOnay = u.UyeOnay
                               
                             }).FirstOrDefault();
            return query;
        }

        public void UyeOnay(int UyeId)
        {


            var query = (from a in _context.Uyeler where a.UyeId == UyeId select a).FirstOrDefault();
            Uyeler uye = new Uyeler();
            if (query.UyeOnay == true)
            {

                uye.UyeId = query.UyeId;
                uye.UyeOnay = false;
            }
            else
            {
                uye.UyeId = query.UyeId;
                uye.UyeOnay= true;
            }

            ContextDataModel db = new ContextDataModel();
            db.Uyeler.Attach(uye);
            db.Entry(uye).Property(x => x.UyeOnay).IsModified = true;
            db.SaveChanges();
        }
    }
}
