using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.Webbapp.Models;

namespace MyCommunity.DataLayer.Repositories
{
    public class UserRepository : BasicOperations<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDatabaseManager DbManager) : base(DbManager)
        {
        }
    }

    public interface IUserRepository : GenericInterfaceRepository<ApplicationUser>
    {
    }
}
