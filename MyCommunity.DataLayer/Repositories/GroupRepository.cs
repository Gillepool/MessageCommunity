using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Repositories
{
    public class GroupRepository : BasicOperations<Group>, IGroupRepository
    {
        public GroupRepository(IDatabaseManager DbManager) : base(DbManager)
        {
        }
    }

    public interface IGroupRepository : GenericInterfaceRepository<Group>
    {
    }
}
