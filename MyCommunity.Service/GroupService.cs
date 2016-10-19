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
    public class GroupService : IGroupService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IUnitOfWork unitOfWork;

        public GroupService(IMessageRepository messageRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, IGroupRepository groupRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.groupRepository = groupRepository;
        }

        public Group GetGroupById(string id)
        {
            return groupRepository.GetById(id);
        }

        public void CreateGroup(Group group)
        {
            groupRepository.Insert(group);
        }

        public void DeleteGroup(Group group)
        {
            groupRepository.Remove(group);
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return groupRepository.GetAll();
        }

        public void UpdateGroupDatabase()
        {
            unitOfWork.CommitToDatabase();
        }

     
    }

    public interface IGroupService
    {
        Group GetGroupById(string id);
        void CreateGroup(Group group);
        void DeleteGroup(Group group);
        IEnumerable<Group> GetAllGroups();
        void UpdateGroupDatabase();
    }
}
