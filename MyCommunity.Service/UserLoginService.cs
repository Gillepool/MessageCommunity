using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.DataLayer.Repositories;
using MyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.Service
{
    public class UserLoginService : IUserLoginService
    {

        private readonly IUserLoginRepository userLoginRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserLoginService(IUserLoginRepository userLoginRepository, IUnitOfWork unitOfWork)
        {
            this.userLoginRepository = userLoginRepository;
            this.unitOfWork = unitOfWork;
        }

        public void SaveUserLogin()
        {
            unitOfWork.CommitToDatabase();
        }

        public IEnumerable<UserLogin> GetUserLogins(string id)
        {
            return userLoginRepository.GetMany(ul => ul.LoggedInUser.Id == id);
        }
    }

    public interface IUserLoginService
    {
        IEnumerable<UserLogin> GetUserLogins(string id);
        void SaveUserLogin();
    }
}
