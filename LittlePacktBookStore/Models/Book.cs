using System.ComponentModel.DataAnnotations;

namespace LittlePacktBookStore.Models
{
    public class Book
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Book Title"), MinLength(2, ErrorMessage = " Minimum lenght is 2 characters.")]
        public string Title {  get; set; }
        public string Description {  get; set; }
        public string Author {  get; set; }
        public string PublishDate {  get; set; }
        public double Price {  get; set; }
        public string Image {  get; set; }
    }
}
