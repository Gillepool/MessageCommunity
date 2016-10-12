using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Infrastructure
{
    public interface GenericInterfaceRepository<T> where T : class
    {
        // Queries that updates database does not send the command to the database directly, need to SaveChanes
        void Insert(T entity);
        void Remove(T entity);
        void Update(T entit);
        T GetById(string id);
        T GetByName(string name);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate);
    }
}
