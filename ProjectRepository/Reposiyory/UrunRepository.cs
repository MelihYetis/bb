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
    public class UrunRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public UrunRepository(ContextDataModel dbContext)
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

        public List<AltKategoriler> AltKategoriList(int KategoriId)
        {
            var altKategoriler = (from a in _context.AltKategoriler where a.UstKategoriId == KategoriId select a).ToList();


            return altKategoriler;
        }

        public List<BirAltKategoriler> BirAltKategoriList(int AltKategoriId)
        {
            var biraltKategoriler = (from a in _context.BirAltKategoriler where a.AltKategoriId == AltKategoriId select a).ToList();
            return biraltKategoriler;
        }

        public IList<Urunler> Urunler()
        {
            var query = (from s in _context.Urunler.OrderBy(m => m.UrunAdi)


                         select s).ToList();

            return query;

        }

        public Urunler Urun(int UrunId)
        {
            var query = (from i in _context.Urunler where i.UrunId == UrunId select i).FirstOrDefault();
            return query;
        }

        public void UrunGenelBilgiGuncelle(Urunler Urun)
        {
            var yeniUrun = new Urunler
            {
                UrunId = Urun.UrunId,
                UrunPiyasaFiyati = Urun.UrunPiyasaFiyati,
                UrunAdi = Urun.UrunAdi,
                UrunKisaAciklama = Urun.UrunKisaAciklama,
                UrunSatisFiyati = Urun.UrunSatisFiyati,
                UrunAciklama = Urun.UrunAciklama,
                ParaBirimi = Urun.ParaBirimi,
                UrunAnaSayfa = Urun.UrunAnaSayfa,
                UrunYeniUrun = Urun.UrunYeniUrun
            };
            using (var d = new ContextDataModel())
            {
                _context.Urunler.Attach(yeniUrun);
                _context.Entry(yeniUrun).Property(y => y.UrunAdi).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.UrunKisaAciklama).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.UrunPiyasaFiyati).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.UrunSatisFiyati).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.UrunAciklama).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.ParaBirimi).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.UrunAnaSayfa).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.UrunYeniUrun).IsModified = true;
                _context.SaveChanges();
            }
        }

        public void UrunSeoGuncelle(Urunler Urun)
        {
            var yeniUrun = new Urunler
            {
                UrunId = Urun.UrunId,
                UrunMetaTitle = Urun.UrunMetaTitle,
                UrunMetaDescription = Urun.UrunMetaDescription,
                UrunAnahtarKelimeler = Urun.UrunAnahtarKelimeler,

            };
            using (var d = new ContextDataModel())
            {
                _context.Urunler.Attach(yeniUrun);
                _context.Entry(yeniUrun).Property(y => y.UrunMetaTitle).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.UrunMetaDescription).IsModified = true;
                _context.Entry(yeniUrun).Property(y => y.UrunAnahtarKelimeler).IsModified = true;

                _context.SaveChanges();
            }


        }
        public Urunler SelectUrun(int UrunId)
        {
            var query = _context.Urunler.Where(m => m.UrunId == UrunId).FirstOrDefault();
            
            return query;
        }
    }
}
