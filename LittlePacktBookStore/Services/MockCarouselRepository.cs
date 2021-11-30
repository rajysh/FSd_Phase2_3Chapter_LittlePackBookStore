using LittlePacktBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LittlePacktBookStore.Services
{
    public class MockCarouselRepository : IRepository<Carousel>
    {

        List<Carousel> carousels;   
        
        public MockCarouselRepository()
        {
            carousels = new List<Carousel>()
            {
                new Carousel()
                {
                    Id = 1,
                    Title = "Discount Books",
                    Description = "Discount Books get them all",
                    ImageURL = "book1.jpg"
                },
                new Carousel()
                {
                    Id = 2,
                    Title = "New Books",
                    Description = "All brand new books",
                    ImageURL = "book2.png"
                },
                new Carousel()
                {
                    Id = 3,
                    Title = "Subscription",
                    Description = "Discount on monthly subscription",
                    ImageURL = "book3.jpg"
                }
            };
        }
        public bool Add(Carousel item)
        {
            try
            {
                Carousel carousel = item;
                carousel.Id = carousels.Max(x => x.Id) + 1;
                carousels.Add(carousel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Carousel item)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Carousel item)
        {
            throw new System.NotImplementedException();
        }

        public Carousel Get(int id)
        {
            return carousels.FirstOrDefault(x  => x.Id == id);
        }

        public IEnumerable<Carousel> GetAll()
        {
            return carousels.ToList();
        }
    }
}
