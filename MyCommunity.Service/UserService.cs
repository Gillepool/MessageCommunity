using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.DataLayer.Repositories;
using MyCommunity.Webbapp.Models;

namespace MyCommunity.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public ApplicationUser GetUser(string id)
        {
            return userRepository.GetById(id);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return userRepository.GetAll();
        }

        public void updateUser()
        {
            unitOfWork.CommitToDatabase();
        }

    }

    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUser(string id);
        void updateUser();
    }
}
