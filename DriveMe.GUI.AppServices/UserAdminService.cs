using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading;
using Driveme.Domain.Services.Factories;
using DriveMe.Domain.Models;
using DriveMe.Infrastructure;

namespace DriveMe.GUI.AppServices
{
    public interface IUserAdminService: IBaseAppService
    {
        User GetById(Guid userId);
        User GetByLogin(string login);
        User GetByPhone(string phone);
        User ModifyProfile(User user);
        void ChangePhone(Guid userId, string newPhone);
        void ChangeRole(User user, Role newRole);
        void DeleteProfile(User user);
        void DeleteProfile(Guid userId);
        void SendEmail(Guid userid, Email message);
        void ChangePassword(User user, string newPassword);
        Guid CreateProfile(User user);
    }

    public class UserAdminService:BaseAppService<User>, IUserAdminService
    {
        public UserAdminService() { }
        public UserAdminService(IBaseFactory<User> factory, IRepository<User> repository) : base(factory, repository)
        {

        }


        public User GetById(Guid userId)
        {
            if(userId ==default(Guid))
                throw new ArgumentException("User Id is empty");
            return repository.GetById(userId);
        }

        public User GetByLogin(string login)
        {
            if(string.IsNullOrEmpty(login))
                throw new ArgumentException("Login is empty");

            User user = repository.Get(x => x.Login == login).FirstOrDefault();

            if (user == null)
                throw new ObjectNotFoundException($"User with login {login} not found.");

            return user;
        }

        public User GetByPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                throw new ArgumentException("Phone is empty");

            User user = repository.Get(x => x.Login == phone).FirstOrDefault();

            if (user == null)
                throw new ObjectNotFoundException($"User with phone {phone} not found.");

            return user;
        }

        

        public void ChangeRole(User user, Role newRole)
        {
           if(user == null)
                throw new NullReferenceException("User is null");
            user.Role = newRole;
            repository.Update(user);
        }

        public User ModifyProfile(User user)
        {
            if(user==null)
                throw new NullReferenceException("User is null");

            if (!user.Validate())
                throw new ArgumentException("User is not valid or is null");
            repository.Update(user);

            return user;
        }

        public void ChangePhone(Guid userId, string newPhone)
        {
            User user = repository.GetById(userId);
            if(user == null)
                throw new ObjectNotFoundException($"User with ID {userId} not found.");
            user.Phone = newPhone;
            repository.Update(user);
        }

        public void DeleteProfile(User user)
        {
            if (user == null)
                throw new NullReferenceException("User is null");
            
            repository.Delete(user);

        }

        public void DeleteProfile(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void SendEmail(Guid userid, Email message)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(User user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Guid CreateProfile(User user)
        {
            User newUser = factory.Create(user);
            if (!newUser.Validate())
            {
                throw new ArgumentException("User profile is not valid");
            }
            repository.Insert(newUser);

            return newUser.Id;

        }
    }
}