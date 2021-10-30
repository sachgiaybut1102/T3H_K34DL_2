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
    public class CustomerDAO : BaseDAO, ICustomerDAO
    {
        public async Task<bool> Add(Customer item)
        {
            try
            {
                _context.Customers.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public async  Task<bool> Delete(string id)
        {
            try
            {
                Customer entity = await GetSingleByID(id);

                if (entity != null)
                {
                    _context.Customers.Remove(entity);

                    await _context.SaveChangesAsync();

                    return true;
                }

            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public async Task<List<Customer>> Getall()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();

            return customers;
        }

        public async Task<List<Customer>> GetByKeyword(string keyword)
        {
            List<Customer> customers = await _context.Customers
                 .Where(t => t.ID.Contains(keyword))
                 .ToListAsync();

            return customers;
        }

        public async Task<IPagedList<Customer>> GetPagedList(int page, int pageSize, string keyword)
        {
            List<Customer> customers = await GetByKeyword(keyword);

            IPagedList<Customer> pagedListCustomers = customers.ToPagedList(page, pageSize);

            return pagedListCustomers;
        }

        public async Task<Customer> GetSingleByID(string id)
        {
            Customer customer = await _context.Customers.FindAsync(id);

            return customer;
        }

        public async  Task<bool> Update(Customer item)
        {
            try
            {
                Customer entity = await GetSingleByID(item.ID);

                entity.Password = item.Password;
                entity.FullName = item.FullName;
                entity.Photo = item.Photo;
                entity.EMail = item.EMail;
                entity.Activated = item.Activated;

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