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
    public class BannerRepository<T> :ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public BannerRepository(ContextDataModel dbContext)
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

        public List<Banner> listBanner () //_BannerResimList sayfasınsa resimleri listeliyor...
        {
            ContextDataModel db = new ContextDataModel();
            List<Banner> listbanner = (from i in db.Bannerlar select i).ToList();

            return listbanner;
        }

        public Banner BannerResimDuzenle (int BannerId)
        {
            var query = (from bannerModel in _context.Bannerlar where bannerModel.BannerId == BannerId select bannerModel).FirstOrDefault();
            return query;
        }

        public void BannerDuzenlenmisUpdate(Banner _banner)
        {
            if (_banner.BannerImagePath == null)
            {
                var yeniBanner = new Banner { BannerId = _banner.BannerId, BannerBaslik = _banner.BannerBaslik, BannerMetin = _banner.BannerMetin, BannerUrl = _banner.BannerUrl };
                using (var d = new ContextDataModel())
                {
                    _context.Bannerlar.Attach(yeniBanner);
                    _context.Entry(yeniBanner).Property(y => y.BannerBaslik).IsModified = true;
                    _context.Entry(yeniBanner).Property(y => y.BannerMetin).IsModified = true;
                    _context.Entry(yeniBanner).Property(y => y.BannerUrl).IsModified = true;
                    

                    _context.SaveChanges();
                } 
            }
            else
            {
                var yeniBanner = new Banner { BannerId = _banner.BannerId, BannerBaslik = _banner.BannerBaslik, BannerMetin = _banner.BannerMetin, BannerUrl = _banner.BannerUrl,BannerImage=_banner.BannerImage,BannerImagePath=_banner.BannerImagePath };
                using (var d = new ContextDataModel())
                {
                    _context.Bannerlar.Attach(yeniBanner);
                    _context.Entry(yeniBanner).Property(y => y.BannerBaslik).IsModified = true;
                    _context.Entry(yeniBanner).Property(y => y.BannerMetin).IsModified = true;
                    _context.Entry(yeniBanner).Property(y => y.BannerUrl).IsModified = true;
                    _context.Entry(yeniBanner).Property(y => y.BannerImage).IsModified = true;
                    _context.Entry(yeniBanner).Property(y => y.BannerImagePath).IsModified = true;
                    _context.SaveChanges();
                }
            }
            
        }
    }
}
