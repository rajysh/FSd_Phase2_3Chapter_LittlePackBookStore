using LittlePacktBookStore.Models;
using LittlePacktBookStore.Services;
using LittlePacktBookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LittlePacktBookStore.Controllers
{
    public class HomeController : Controller
    {
        //List<Book> books;
        //List<Carousel> carousels;
        IRepository<Book> bookRepository;
        IRepository<Carousel> carouselRepository;
        IRepository<Order> orderRepository;

        public HomeController(IRepository<Book> books, IRepository<Carousel> carousels, IRepository<Order> orders)
        {
            //books = new List<Book>();
            //carousels = new List<Carousel>();
            //bookRepository = new MockBooksRepository();
            //carouselRepository = new MockCarouselRepository();
            bookRepository = books;
            carouselRepository = carousels;
            orderRepository = orders;
        }

        //Home page
        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Books = bookRepository.GetAll(),
                Carousels = carouselRepository.GetAll()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                Book item = new Book()
                {
                    Id = bookRepository.GetAll().Max(m => m.Id) + 1,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    PublishDate = book.PublishDate,
                    Price = book.Price,
                    Image = book.Image
                };

                bookRepository.Add(item);

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        //About us page
        public IActionResult About()
        {
            return View();
        }

        //Contact Us page
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Test()
        {
            ViewBag.BookName = "New Book";
            return View(new Book()
            {
                Id = 5,
                Title = "Fantastic Book",
                Author = "Me",
                Description = "Book description here"
            });
        }

        public IActionResult Details(int id)
        {
            Book book = bookRepository.Get(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Order(int? id)
        {
            if (id != null && id >= 0)
            {
                OrderViewModel model = new OrderViewModel()
                {
                    BookToOrder = bookRepository.Get((int)id),
                    OrderDetails = new Order()
                    {
                        BookId = (int)id
                    }
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Order(int id, Order orderDetails)
        {
            if(ModelState.IsValid)
            {
                if(bookRepository.GetAll().Count(x => x.Id == orderDetails.BookId) >= 1)
                {
                    orderDetails.BookId = id;
                    orderRepository.Add(orderDetails);
                    return RedirectToAction("ThankYou");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(new OrderViewModel()
                {
                    OrderDetails = orderDetails,
                    BookToOrder = bookRepository.Get(id)
                });
            }
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult OrdersList()
        {
            return View(orderRepository.GetAll());
        }
    }
}
