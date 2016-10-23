using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.DataLayer.Repositories;
using MyCommunity.Models;
using System.Collections.Generic;


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

        public void updateDatabase()
        {
            unitOfWork.CommitToDatabase();
        }

        public void UpdateUser(ApplicationUser user)
        {
            userRepository.Update(user);
        }

        public IEnumerable<ApplicationUser> GetAllUsersBut(string id)
        {
            return userRepository.GetMany(u => u.Id != id);
        }

     
    }

    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUser(string id);
        IEnumerable<ApplicationUser> GetAllUsersBut(string id);
        void updateDatabase();
        void UpdateUser(ApplicationUser user);
    }
}
