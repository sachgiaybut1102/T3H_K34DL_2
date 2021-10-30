using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebSales.Models.EF;

namespace WebSales.Models.DAO
{
    public class OrderDAO : BaseDAO, IOrderDAO
    {
        public async Task<bool> Add(Order item)
        {
            try
            {
                _context.Orders.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Order entity = await GetSingleByID(id);

                if (entity != null)
                {
                    _context.Orders.Remove(entity);

                    await _context.SaveChangesAsync();

                    return true;
                }

            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public async Task<List<Order>> Getall()
        {
            List<Order> orders = await _context.Orders.ToListAsync();

            return orders;
        }

        public async Task<List<Order>> GetByKeyword(string keyword)
        {
            List<Order> orders = await _context.Orders
                            .Where(t => t.Address.Contains(keyword))
                            .ToListAsync();

            return orders;
        }

        public async Task<IPagedList<Order>> GetPagedList(int page, int pageSize, string keyword)
        {
            List<Order> orders = await GetByKeyword(keyword);

            IPagedList<Order> pagedListOrders = orders.ToPagedList(page, pageSize);

            return pagedListOrders;
        }

        public async Task<Order> GetSingleByID(int id)
        {
            Order order = await _context.Orders.FindAsync(id);

            return order;
        }

        public async Task<bool> Update(Order item)
        {
            try
            {
                Order entity = await GetSingleByID(item.ID);

                entity.Address = item.Address;
                entity.Amount = item.Amount;
                entity.Description = item.Description;

                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {

            }

            return false;
        }
    }
}