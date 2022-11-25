using DataAccessLayerEntityFrameWork.ContextDbs;
using DomainLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerEntityFrameWork.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContextSystem _context { get; set; }
        internal DbSet<T> dbSet;
        public BaseRepository(DbContextSystem context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public async Task<T> AddNewItem(T Item)
        {
            await dbSet.AddAsync(Item);
            await _context.SaveChangesAsync();
            return Item;
        }

        public void DeleteItem(int Id)
        {
            dbSet.Remove(dbSet.Find(Id));
            _context.SaveChanges();
        }

        public async Task<List<T>> GetAllData(Expression<Func<T, bool>> filter)
        {
            var Data = await dbSet.Where(filter).ToListAsync();
            return Data;
        }

    }
}
