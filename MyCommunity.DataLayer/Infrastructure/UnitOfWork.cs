using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseManager dbManager;
        private DatabaseContext dbContext;

        public UnitOfWork(IDatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }
        public DatabaseContext DbContext { get { return dbContext ?? (dbContext = dbManager.Init()); } }

        public void CommitToDatabase()
        {
            DbContext.Commit();
        }
    }
}
