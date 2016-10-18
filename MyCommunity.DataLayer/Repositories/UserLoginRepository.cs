using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Repositories
{
    public class UserLoginRepository : BasicOperations<UserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(IDatabaseManager DbManager) : base(DbManager)
        {
        }
    }

    public interface IUserLoginRepository : GenericInterfaceRepository<UserLogin>
    {
    }
}
