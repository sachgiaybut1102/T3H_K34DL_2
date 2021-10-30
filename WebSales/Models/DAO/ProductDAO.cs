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
    public class ProductDAO : BaseDAO, IProductDAO
    {
        public async Task<bool> Add(Product item)
        {
            try
            {
                _context.Products.Add(item);

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
                Product entity = await GetSingleByID(id);

                if (entity != null)
                {
                    _context.Products.Remove(entity);

                    await _context.SaveChangesAsync();

                    return true;
                }

            }
            catch (Exception ex)
            {

            }

            return false; 
        }

        public async Task<List<Product>> Getall()
        {
            List<Product> products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetByKeyword(string keyword)
        {
            List<Product> products = await _context.Products
                .Where(t => t.Name.Contains(keyword))
                .ToListAsync();

            return products;
        }

        public async Task<IPagedList<Product>> GetPagedList(int page, int pageSize, string keyword)
        {
            List<Product> products = await GetByKeyword(keyword);

            IPagedList<Product> pagedListProducts = products.ToPagedList(page, pageSize);

            return pagedListProducts;
        }

        public async Task<Product> GetSingleByID(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            return product;
        }

        public async Task<bool> Update(Product item)
        {
            try
            {
                Product entity = await GetSingleByID(item.ID);

                entity.Name = item.Name;
                entity.UnitPrice = item.UnitPrice;
                entity.Image = item.Image;
                entity.ProductDate = item.ProductDate;
                entity.Available = item.Available;
                entity.Category = item.Category;
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