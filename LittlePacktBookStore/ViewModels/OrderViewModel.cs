using LittlePacktBookStore.Models;

namespace LittlePacktBookStore.ViewModels
{
    public class OrderViewModel
    {
        public Book BookToOrder {  get; set; }
        public Order OrderDetails {  get; set; }
    }
}
