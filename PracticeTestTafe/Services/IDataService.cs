using PracticeTestTafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PracticeTestTafe.Services
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    }
}
