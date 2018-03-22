using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticeTestTafe.Models;

namespace PracticeTestTafe.Services
{
    public class DataService<T> : IDataService<T> where T : class
    {
        private MyDbContext _dbContext;
        private DbSet<T> _dbSet;

        public DataService()
        {
            _dbContext = new MyDbContext();
            _dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
