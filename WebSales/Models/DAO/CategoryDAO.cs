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
    public class CategoryDAO : BaseDAO, ICategoryDAO
    {
        public async Task<bool> Add(Category item)
        {
            try
            {
                _context.Categories.Add(item);

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
                Category entity = await GetSingleByID(id);

                if (entity != null)
                {
                    _context.Categories.Remove(entity);

                    await _context.SaveChangesAsync();

                    return true;
                }

            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public async Task<List<Category>> Getall()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<List<Category>> GetByKeyword(string keyword)
        {
            List<Category> categories = await _context.Categories
                .Where(t => t.Name.Contains(keyword) || t.NameVN.Contains(keyword))
                .ToListAsync();

            return categories;
        }

        public async Task<IPagedList<Category>> GetPagedList(int page, int pageSize, string keyword)
        {
            List<Category> categories = await GetByKeyword(keyword);

            IPagedList<Category> pagedListCategories = categories.ToPagedList(page, pageSize);

            return pagedListCategories;
        }

        public async Task<Category> GetSingleByID(int id)
        {
            Category category = await _context.Categories.FindAsync(id);

            return category;
        }

        public async Task<bool> Update(Category item)
        {
            try
            {
                Category entity = await GetSingleByID(item.ID);

                entity.Name = item.Name;
                entity.NameVN = item.NameVN;

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