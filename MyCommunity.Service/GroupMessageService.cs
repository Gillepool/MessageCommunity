//using MyCommunity.DataLayer.Infrastructure;
//using MyCommunity.DataLayer.Repositories;
//using MyCommunity.Models;
//using MyCommunity.Service;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyCommunity.Service
//{
//    public class GroupMessageService : IGroupMessageService
//    {

//        private readonly IGroupMessageRepository groupMessageRepository;
//        private readonly IUserRepository userRepository;
//        private readonly IUnitOfWork unitOfWork;

//        public GroupMessageService(IGroupMessageRepository groupMessageRepository, UnitOfWork unitOfWork, IUserRepository userRepository)
//        {
//            this.groupMessageRepository = groupMessageRepository; ;
//            this.unitOfWork = unitOfWork;
//            this.userRepository = userRepository;
//        }

//        public GroupMessage GetGroupMessageById(string id)
//        {
//            return groupMessageRepository.GetById(id);
//        }

//        public void CreateGroupMessage(GroupMessage group)
//        {
//            groupMessageRepository.Insert(group);
//        }

//        public void DeleteGroupMessage(GroupMessage group)
//        {
//            groupMessageRepository.Remove(group);
//        }

//        public IEnumerable<GroupMessage> GetAllGroupMessagesFromGroup(Group group)
//        {
//            return groupMessageRepository.GetMany(gm => gm.Group == group);
//        }

//        public void UpdateGroupMessageDatabase()
//        {
//            unitOfWork.CommitToDatabase();
//        }
//    }

//    public interface IGroupMessageService
//    {
//        GroupMessage GetGroupMessageById(string id);
//        void CreateGroupMessage(GroupMessage group);
//        void DeleteGroupMessage(GroupMessage group);
//        IEnumerable<GroupMessage> GetAllGroupMessagesFromGroup(Group group);
//        void UpdateGroupMessageDatabase();
//    }
//}
