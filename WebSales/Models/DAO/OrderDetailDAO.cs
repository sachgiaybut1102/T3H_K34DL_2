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
    public class OrderDetailDAO : BaseDAO, IOrderDetailDAO
    {
        public async Task<bool> Add(OrderDetail item)
        {

            try
            {
                _context.OrderDetails.Add(item);

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
                OrderDetail entity = await GetSingleByID(id);

                if (entity != null)
                {
                    _context.OrderDetails.Remove(entity);

                    await _context.SaveChangesAsync();

                    return true;
                }

            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public async Task<bool> DeleteByOrderID(int id)
        {
            try
            {
                List<OrderDetail> orderDetails = await GetByOrderID(id);

                _context.OrderDetails.RemoveRange(orderDetails);

                await _context.SaveChangesAsync();

                return true;


            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public async Task<List<OrderDetail>> Getall()
        {
            List<OrderDetail> orderDetails = await _context.OrderDetails.ToListAsync();

            return orderDetails;
        }

        public async Task<List<OrderDetail>> GetByKeyword(string keyword)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            return orderDetails;
        }

        public async Task<List<OrderDetail>> GetByOrderID(int id)
        {
            List<OrderDetail> orderDetails = await _context.OrderDetails
                .Where(t => t.OrderID == id)
                .ToListAsync();

            return orderDetails;
        }

        public async Task<IPagedList<OrderDetail>> GetPagedList(int page, int pageSize, string keyword)
        {
            List<OrderDetail> orderDetails = await GetByKeyword(keyword);

            IPagedList<OrderDetail> pagedListOrderDetails = orderDetails.ToPagedList(page, pageSize);

            return pagedListOrderDetails;
        }

        public async Task<OrderDetail> GetSingleByID(int id)
        {
            OrderDetail orderDetail = await _context.OrderDetails.FindAsync(id);

            return orderDetail;
        }

        public async Task<bool> Update(OrderDetail item)
        {
            try
            {
                OrderDetail entity = await GetSingleByID(item.ID);

                entity.Quantity = item.Quantity;
                entity.UnitPrice = item.UnitPrice;

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