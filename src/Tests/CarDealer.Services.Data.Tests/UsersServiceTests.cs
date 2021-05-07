namespace CarDealer.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Services.Data.Implementations;
    using CarDealer.Web.ViewModels.InputModels.Users;
    using CarDealer.Web.ViewModels.Users;

    using Moq;
    using Xunit;

    public class UsersServiceTests : BaseServiceTests
    {
        public static List<ApplicationUser> GetTestData()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "UserName",
                    NormalizedUserName = "USERNAME",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    PhoneNumber = "1234567890",
                    Email = "email@gmail.com",
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "UserName2",
                    NormalizedUserName = "USERNAME2",
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    PhoneNumber = "1234567890",
                    Email = "email2@gmail.com",
                },
            };
        }

        [Fact]
        public void CheckIfGetUserByIdMethodReturnsTheCorrectUser()
        {
            var repository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            repository.Setup(r => r.All())
                .Returns(GetTestData().AsQueryable());

            IUsersService usersService = new UsersService(repository.Object);
            UserViewModel user = usersService.GetUserById("2");

            Assert.Equal("UserName2", user.UserName);
            Assert.Equal("FirstName2", user.FirstName);
            Assert.Equal("LastName2", user.LastName);
            Assert.Equal("1234567890", user.PhoneNumber);
            Assert.Equal("email2@gmail.com", user.Email);
        }

        [Fact]
        public async Task CheckIfUpdateUserInfoMethodWorksCorrectly()
        {
            var repository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            repository.Setup(r => r.All())
                .Returns(GetTestData().AsQueryable());

            IUsersService usersService = new UsersService(repository.Object);

            var inputModel = new UserInputModel
            {
                UserName = "NewUsername",
                FirstName = "NewFirstName",
                LastName = "NewLastName",
                Email = "NewEmail",
                PhoneNumber = "NewPhoneNumber",
            };

            var updatedUser = await usersService.UpdateUserInfo("2", inputModel);

            Assert.Equal(inputModel.UserName, updatedUser.UserName);
            Assert.Equal(inputModel.FirstName, updatedUser.FirstName);
            Assert.Equal(inputModel.LastName, updatedUser.LastName);
            Assert.Equal(inputModel.PhoneNumber, updatedUser.PhoneNumber);
            Assert.Equal(inputModel.Email, updatedUser.Email);
        }
    }
}
