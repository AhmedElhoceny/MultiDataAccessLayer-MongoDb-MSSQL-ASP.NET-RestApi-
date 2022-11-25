using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllData(Expression<Func<T, bool>> filter);
        Task<T> AddNewItem(T Item);
        void DeleteItem(int Id);
    }
}
