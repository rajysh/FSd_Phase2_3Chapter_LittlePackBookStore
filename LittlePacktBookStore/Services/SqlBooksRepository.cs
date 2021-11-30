using LittlePacktBookStore.Data;
using LittlePacktBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LittlePacktBookStore.Services
{
    public class SqlBooksRepository : IRepository<Book>
    {
        private LittlePacktBookStoreDbContext _context;
        public SqlBooksRepository(LittlePacktBookStoreDbContext context)
        {
            _context = context;
        }
        public bool Add(Book item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Delete(Book item)
        {
            try
            {
                Book book = Get(item.Id);
                if(book != null)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Edit(Book item)
        {
            throw new System.NotImplementedException();
        }

        public Book Get(int id)
        {
            if(_context.Books.Count(x => x.Id == id) > 0)
            {
                return _context.Books.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }
    }
}
