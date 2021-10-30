using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebSales.Models.DAO
{
    public interface IBaseDAO<T, U>
    {
        Task<List<T>> Getall();
        Task<T> GetSingleByID(U id);
        Task<List<T>> GetByKeyword(string keyword);
        Task<bool> Add(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(U id);
    }
}