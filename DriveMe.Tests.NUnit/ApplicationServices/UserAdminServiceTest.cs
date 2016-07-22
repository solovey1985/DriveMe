using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Driveme.Domain.Services.Factories;
using DriveMe.DAL.Repositories;
using DriveMe.DAL.UnitsOfWork;
using DriveMe.Domain.Models;
using DriveMe.GUI.AppServices;
using NUnit.Framework;
using Moq;
namespace DriveMe.Tests.NUnit.ApplicationServices
{
    [TestFixture(Category = "AppServices")]
    public class UserAdminServiceTest
    {
        private UserAdminService service;
        Mock<IUserUnitOfWork> userUnitOfWorkMock;
        Mock<IUserRepository> userRepositoryMock;
        Mock<IUserFactory> userFactoryMock;
        private IUserFactory userFactory;
        private IUserUnitOfWork userUnitOfWork;
        private IUserRepository userRepository;
        [SetUp]
        public void Init()
        {
            service = CreateUserAdminService();
        }

        [TearDown]
        public void TearDown() {}

        [Test]
        public void Can_CreateProfile_WithValidData()
        {
            User user = CreateSampleUser(); //User without Id(Guid)

            Guid actualGuid = service.CreateProfile(user);
            Assert.True(actualGuid!=default(Guid));
            userRepositoryMock.Verify(v=>v.Insert(It.IsAny<User>()), Times.AtLeastOnce);
            userFactoryMock.Verify(f=>f.Create(It.IsAny<User>()), Times.AtLeastOnce);
            
            
        }

        [Test]
        public void Can_ModifyProfile_WithValidData()
        {
            //Arrange
            User user = CreateSampleUser();
            user.Id = Guid.NewGuid();
            user.FirstName = "Another First Name";
            User notChanged = CreateSampleUser();
            //Act 
            service.ModifyProfile(user);
            //Assert
            Assert.AreNotEqual(user.FirstName, notChanged.FirstName);
            Assert.AreNotEqual(user.Id, notChanged.Id);
            userRepositoryMock.Verify(x=>x.Update(It.IsAny<User>()), Times.AtLeastOnce);
            
        }
        [Test]
        public void Can_ChangeEmail_WithValidData()
        {
            //Arrange 
            User sample = CreateSampleUser();
            User actual = CreateSampleUser();
            actual.Phone = "+3800000000";
            //Act 
            service.ChangePhone(actual.Id, actual.Phone);
            //Assert
            userRepositoryMock.Verify(x => x.Update(It.IsAny<User>()), Times.AtLeastOnce);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.AtLeastOnce);
        }
        [Test]
        public void Can_DeleteProfile_WithValidData()
        {
            //Arrange 
            User actualUser = CreateSampleUser();
            actualUser.Id = Guid.NewGuid();
            //Act 
            service.DeleteProfile(actualUser);
            //Assert
            userRepositoryMock.Verify(x => x.Delete(It.IsAny<User>()), Times.AtLeastOnce);
        }
        [Test]
        public void Can_ChangeRole_WithValidData()
        {
            //Arrange 
            User sample = CreateSampleUser();       //Created with Role.User
            User actualUser = CreateSampleUser();   //Created with Role.User
            //Act 
            service.ChangeRole(actualUser, Role.Admin);
            //Assert
            Assert.AreNotEqual(sample.Role, actualUser.Role);
            userRepositoryMock.Verify(v=>v.Update(It.IsAny<User>()),Times.AtLeastOnce);
        }

        [Test]
        public void Can_GetUserById_WithValidData()
        {
            //Arrange 
            User actual;
            //Act 
            actual = service.GetById(Guid.NewGuid());
            //Assert
            Assert.NotNull(actual);
            userRepositoryMock.Verify(v=>v.GetById(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        #region Helpers

        private UserAdminService CreateUserAdminService()
        {
            userFactoryMock = new Mock<IUserFactory>();
            userFactoryMock.Setup(p => p.Create(It.IsAny<User>())).Returns<User>((User u) => { u.Id = Guid.NewGuid();return u;});
            userUnitOfWorkMock = new Mock<IUserUnitOfWork>();
            userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(CreateSampleUser);

            UserAdminService serv = new UserAdminService(userFactoryMock.Object, userRepositoryMock.Object);


            return serv;
        }

        private User CreateSampleUser()
        {
            User sample = new User()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                Phone = "+308236545646",
                Email = "simple@email.com",
                Login = "simple",
                Role = Role.User,
                FavouriteAddress = "Favorite Address",
                HomeAddress = "Home Address",
                WorkAddress = "WorkAddress"
            };

            return sample;
        }
        #endregion
    }
}
