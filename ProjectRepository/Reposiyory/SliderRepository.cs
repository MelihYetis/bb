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
    public class SliderRepository<T> : ImyReposiory<T> where T : class
    {
        protected ContextDataModel _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public SliderRepository(ContextDataModel dbContext)
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

        public IList<Slider> ListSlider()
        {
            var query = (from s in _context.Slider.OrderBy(m => m.SliderAdi)


                         select s).ToList();

            return query;

        }

        public Slider slider(int SliderId)
        {
            var query = (from s in _context.Slider where s.SliderId == SliderId select s).FirstOrDefault();
            return (query);
        }

        public IList<SliderResimler> ListSliderResimler(int SliderId)
        {
            var query = (from s in _context.SliderResimler where s.SliderId == SliderId select s).ToList();

            return query;
        }

        public SliderResimler sliderResim(int SliderResimId)
        {
            var query =(from sr in _context.SliderResimler where sr.SliderResimlerId == SliderResimId select sr).FirstOrDefault();

            return query;

        }

        public void SliderResimAciklamaUpdate(SliderResimler sliderResimler)
        {
            if (sliderResimler.SliderResimImageByte== null)
            {
                var yeniResim = new SliderResimler { SliderResimlerId = sliderResimler.SliderResimlerId, SayfaId = sliderResimler.SayfaId, SliderResimAciklama = sliderResimler.SliderResimAciklama, SliderId = sliderResimler.SliderId };
                using (var d = new ContextDataModel())
                {
                    _context.SliderResimler.Attach(yeniResim);
                    _context.Entry(yeniResim).Property(y => y.SayfaId).IsModified = true;
                    _context.Entry(yeniResim).Property(y => y.SliderResimAciklama).IsModified = true;
                    _context.Entry(yeniResim).Property(y => y.SliderId).IsModified = true;

                    _context.SaveChanges();
                }
            }
            else
            {
                var yeniResim = new SliderResimler {SliderResimlerId= sliderResimler.SliderResimlerId, SayfaId = sliderResimler.SayfaId, SliderResimAciklama = sliderResimler.SliderResimAciklama, SliderId = sliderResimler.SliderId,SliderResimImageByte=sliderResimler.SliderResimImageByte };
                using (var d = new ContextDataModel())
                {
                    _context.SliderResimler.Attach(yeniResim);
                    _context.Entry(yeniResim).Property(y => y.SayfaId).IsModified = true;
                    _context.Entry(yeniResim).Property(y => y.SliderResimAciklama).IsModified = true;
                    _context.Entry(yeniResim).Property(y => y.SliderId).IsModified = true;
                    _context.Entry(yeniResim).Property(y => y.SliderResimImageByte).IsModified = true;
                    _context.SaveChanges();
                }
            }

        }
    }
}
