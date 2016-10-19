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

        public Group GetGroupById(int id)
        {
            return this.databaseContext.Groups.Where(m => m.GroupId == id).FirstOrDefault();
        }

       
    }

    public interface IGroupRepository : GenericInterfaceRepository<Group>
    {
        Group GetGroupById(int id);
        
    }
}
