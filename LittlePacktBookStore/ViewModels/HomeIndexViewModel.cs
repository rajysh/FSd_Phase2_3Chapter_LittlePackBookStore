using LittlePacktBookStore.Models;
using System.Collections.Generic;

namespace LittlePacktBookStore.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Carousel> Carousels { get; set; }
    }
}
