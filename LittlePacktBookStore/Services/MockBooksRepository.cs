using LittlePacktBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LittlePacktBookStore.Services
{
    public class MockBooksRepository : IRepository<Book>
    {
        List<Book> books;

        public MockBooksRepository()
        {
            books = new List<Book>(){
            new Book()
            {
                Id = 1,
                Title = "Getting started with ASP.NET Core MVC",
                Description = "Learn to build and run your first application with ASP.NET CORE MVC",
                Author = "Ronnie Rahman",
                PublishDate = "11/09/2020",
                Price = 39.01,
                Image = "book1.jpg"
            },
            new Book()
            {
                Id = 2,
                Title = "Book for Javascript",
                Description = "Learn to build Javascript application",
                Author = "Ronnie Rahman",
                PublishDate = "25/10/2000",
                Price = 59.80,
                Image = "book2.png"
            },
            new Book()
            {
                Id = 3,
                Title = "Getting started with React JS",
                Description = "Learn to build and run your first React Js application with ASP.NET CORE MVC",
                Author = "Ronnie Rahman",
                PublishDate = "25/01/2010",
                Price = 42.50,
                Image = "book3.jpg"
            },
            new Book()
            {
                Id = 4,
                Title = "Javascript and JSON essentials",
                Description = "Use JSON to build and run your first  application",
                Author = "Bruno Joseph O'mello, Sai Sriparasa",
                PublishDate = "April 2018",
                Price = 42.50,
                Image = "book4.jpeg"
            },
            new Book()
            {
                Id = 5,
                Title = "CSharp and .NET Core Test Driven Development",
                Description = "Learn how to apply a test-drivern development process by building ready",
                Author = "Bruno Joseph O'mello, Sai Sriparasa",
                PublishDate = "April 2018",
                Price = 42.50,
                Image = "book4.jpeg"
            },
            new Book()
            {
                Id = 6,
                Title = ".NET Core 2.0 By Example",
                Description = "Build Cross platform solutions with .NET Core 2.0 through real-life scenario",
                Author = "Rishabh Verma, Sai Sriparasa",
                PublishDate = "May 2018",
                Price = 49.99,
                Image = "book3.jpg"
            },
            new Book()
            {
                Id = 7,
                Title = "Beginning CSharp 7 Hands On - The Core Language",
                Description = "A CSharp 7 beginners guid to the core parts of the CSharp Language",
                Author = "Tom Owsiak",
                PublishDate = "August 2017",
                Price = 39.99,

                Image = "book1.jpg"
            },
            new Book()
            {
                Id = 8,
                Title = "Beginning CSharp 7 Hands On - The Core Language",
                Description = "A CSharp 7 beginners guid to the core parts of the CSharp Language",
                Author = "Tom Owsiak",
                PublishDate = "August 2017",
                Price = 39.99,

                Image = "book3.jpg"
            },
            new Book()
            {
                Id = 9,
                Title = "Beginning CSharp 7 Hands On - The Core Language",
                Description = "A CSharp 7 beginners guid to the core parts of the CSharp Language",
                Author = "Tom Owsiak",
                PublishDate = "August 2017",
                Price = 39.99,

                Image = "book1.jpg"
            },
            new Book()
            {
                Id = 10,
                Title = "Beginning CSharp 7 Hands On - The Core Language",
                Description = "A CSharp 7 beginners guid to the core parts of the CSharp Language",
                Author = "Tom Owsiak",
                PublishDate = "August 2017",
                Price = 39.99,
                Image = "book3.jpg"
            },
            new Book()
            {
                Id = 11,
                Title = "Beginning CSharp 7 Hands On - The Core Language",
                Description = "A CSharp 7 beginners guid to the core parts of the CSharp Language",
                Author = "Tom Owsiak",
                PublishDate = "August 2017",
                Price = 39.99,

                Image = "book2.png"
            },
            new Book()
            {
                Id = 12,
                Title = "Beginning CSharp 7 Hands On - The Core Language",
                Description = "A CSharp 7 beginners guid to the core parts of the CSharp Language",
                Author = "Tom Owsiak",
                PublishDate = "August 2017",
                Price = 39.99,
                Image = "book3.jpg"
            },
            new Book()
            {
                Id = 13,
                Title = "Beginning CSharp 7 Hands On - The Core Language",
                Description = "A CSharp 7 beginners guid to the core parts of the CSharp Language",
                Author = "Tom Owsiak",
                PublishDate = "August 2017",
                Price = 39.99,

                Image = "book2.png"
            }
            };

        }

        public bool Add(Book item)
        {
            try
            {
                Book book = item;
                book.Id = books.Max(x => x.Id) + 1;
                books.Add(book);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Book item)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Book item)
        {
            throw new System.NotImplementedException();
        }

        public Book Get(int id)
        {
           // return books.Find(x => x.Id == id); OR
            return books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return books.ToList();       
        }
    }
}
