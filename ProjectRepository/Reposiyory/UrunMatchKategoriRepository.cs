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
    public class UrunMatchKategoriRepository<T> : ImyReposiory<T> where T : class
    {

        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public UrunMatchKategoriRepository(ContextDataModel dbContext)
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
        public IList<ViewModelUrun> UrunMatchKategoriList(int UrunId)
        //public IList<IGrouping<int,ViewModelUrun>> UrunMatchKategoriList (int UrunId)
        {

            var query = (from um in _context.UrunMatchKategori
                        join uk in _context.UstKategoriler on um.UstKategoriId equals uk.UstKategoriId
                        into g
                        from a in g.DefaultIfEmpty()
                        join ak in _context.AltKategoriler on um.AltKategoriId equals ak.AltKategoriId
                        into f
                        from l in f.DefaultIfEmpty()
                        join bak in _context.BirAltKategoriler on um.BirAltKategoriId equals bak.BirAltKategoriId
                        into h
                        from k in h.DefaultIfEmpty()
                        join u in _context.Urunler on um.UrunId equals u.UrunId
                        where um.UrunId == UrunId
                        select new ViewModelUrun
                        {
                            UrunId = um.UrunId,
                            AltKategoriId = um.AltKategoriId,
                            AltKategoriAdi = l.AltKategoriAdi,
                            UstKategoriAdi = a.UstKategoriAdi,
                            UrunAdi = u.UrunAdi,
                            UrunMatchKategoriId = um.UrunMatchKategoriId,
                            BirAltKategoriAdi = k.BirAltKategoriAdi
                        }
                        ).GroupBy(p => new { p.UrunId, p.AltKategoriId, p.AltKategoriAdi, p.UstKategoriAdi, p.UrunAdi, p.UrunMatchKategoriId,p.BirAltKategoriAdi }).ToList();
            

            //var query = (from um in _context.UrunMatchKategori

            //             join ak in _context.AltKategoriler on um.AltKategoriId equals ak.AltKategoriId
            //             into g
            //             from a in g.DefaultIfEmpty()
            //             join uk in _context.UstKategoriler on um.UstKategoriId equals uk.UstKategoriId
            //             join u in _context.Urunler on um.UrunId equals u.UrunId
            //             join b in _context.BirAltKategoriler on a.AltKategoriId equals b.AltKategoriId
            //             into f
            //             from l in f.DefaultIfEmpty()//yeni
            //             where
            //             um.UrunId == UrunId



            //             select new ViewModelUrun
            //             {
            //                 UrunId = um.UrunId,
            //                 AltKategoriId = um.AltKategoriId,
            //                 AltKategoriAdi = a.AltKategoriAdi,
            //                 UstKategoriAdi = uk.UstKategoriAdi,
            //                 UrunAdi = u.UrunAdi,
            //                 UrunMatchKategoriId = um.UrunMatchKategoriId,
            //                 BirAltKategoriAdi = l.BirAltKategoriAdi

            //             }
            //             ).GroupBy(p => new { p.UrunId, p.AltKategoriId, p.AltKategoriAdi, p.UstKategoriAdi, p.UrunAdi, p.UrunMatchKategoriId,p.BirAltKategoriAdi }).ToList();



            List<ViewModelUrun> list = new List<ViewModelUrun>();

            foreach (var item in query)
            {
                list.Add(new ViewModelUrun
                {
                    AltKategoriAdi = item.Key.AltKategoriAdi,
                    UrunId = item.Key.UrunId,
                    UstKategoriAdi = item.Key.UstKategoriAdi,
                    UrunAdi = item.Key.UrunAdi,
                    UrunMatchKategoriId = item.Key.UrunMatchKategoriId,
                    BirAltKategoriAdi = item.Key.BirAltKategoriAdi
                });
            }


            return list;

        }
    }
}
