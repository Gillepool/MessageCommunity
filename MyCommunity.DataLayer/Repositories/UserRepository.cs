using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.DataLayer.Infrastructure;
using System.Collections;
using MyCommunity.Models;

namespace MyCommunity.DataLayer.Repositories
{
    public class UserRepository : BasicOperations<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDatabaseManager DbManager) : base(DbManager)
        {
        }

        public IEnumerable<ApplicationUser> GetAllUsersThatSentMessagesToThisUser(ApplicationUser User)
        {
            IList<ApplicationUser> users;
            using (var db = DbManager.Init())
            {
                users = (from u in db.Users
                         join m in db.Messages on u.Id equals m.SenderId
                         where m.ReceiverId.Contains(User.Id)
                         orderby u.Email
                         select u).ToList();
            }
            return users.Distinct();
        }
    }
    public interface IUserRepository : GenericInterfaceRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetAllUsersThatSentMessagesToThisUser(ApplicationUser UserID);
    }
}