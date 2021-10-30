using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebSales.Models.DAO
{
    public interface IBasePagedListDAO<T>
    {
        Task<IPagedList<T>> GetPagedList(int page, int pageSize, string keyword);
    }
}