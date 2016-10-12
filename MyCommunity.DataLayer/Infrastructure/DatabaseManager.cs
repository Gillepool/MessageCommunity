using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Infrastructure
{
    public class DatabaseManager : Disposable, IDatabaseManager
    {
        DatabaseContext dbContext;
        public DatabaseContext Init()
        {
            //returns dbContext, if null, create a new one
            return dbContext ?? (dbContext = new DatabaseContext());
        }

        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
