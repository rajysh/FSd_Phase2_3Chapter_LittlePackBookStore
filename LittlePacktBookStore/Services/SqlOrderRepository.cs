using LittlePacktBookStore.Data;
using LittlePacktBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LittlePacktBookStore.Services
{
    public class SqlOrderRepository : IRepository<Order>
    {
        private LittlePacktBookStoreDbContext _context;
        public SqlOrderRepository(LittlePacktBookStoreDbContext context)
        {
            _context = context;
        }
        public bool Add(Order item)
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

        public bool Delete(Order item)
        {
            try
            {
                Order order = Get(item.Id);
                if (order != null)
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

        public bool Edit(Order item)
        {
            throw new System.NotImplementedException();
        }

        public Order Get(int id)
        {
            if (_context.Orders.Count(x => x.Id == id) > 0)
            {
                return _context.Orders.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }
    }
}
