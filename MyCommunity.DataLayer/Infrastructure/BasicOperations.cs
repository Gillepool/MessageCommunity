using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Infrastructure
{
    public abstract class BasicOperations<T> where T : class
    {
        private DatabaseContext dbContext;
        private readonly IDbSet<T> dbSet;
        protected IDatabaseManager DbManager{ get; private set; }
        public DatabaseContext databaseContext { get { return dbContext ?? (dbContext = DbManager.Init()); } }
        protected BasicOperations(IDatabaseManager DbManager)
        {
            this.DbManager = DbManager;
            dbSet = databaseContext.Set<T>();
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            databaseContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T entity){
            dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll(){
            return dbSet.ToList();
        }

        public virtual T GetById(string id){
            return dbSet.Find(id);
        }

        public virtual T GetByName(string name)
        {
            return dbSet.Find(name);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault<T>();
        }
    }
}
