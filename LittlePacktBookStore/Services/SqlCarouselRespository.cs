using LittlePacktBookStore.Data;
using LittlePacktBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LittlePacktBookStore.Services
{
    public class SqlCarouselRespository: IRepository<Carousel>
    {
        private LittlePacktBookStoreDbContext _context;
        public SqlCarouselRespository(LittlePacktBookStoreDbContext context)
        {
            _context = context;
        }
        public bool Add(Carousel item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Carousel item)
        {
            try
            {
                Carousel carousel = Get(item.Id);
                if (carousel != null)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Carousel item)
        {
            throw new System.NotImplementedException();
        }

        public Carousel Get(int id)
        {
            if (_context.Carousels.Count(x => x.Id == id) > 0)
            {
                return _context.Carousels.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Carousel> GetAll()
        {
            return _context.Carousels;
        }        
    }
}
