namespace CarDealer.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Repositories;
    using CarDealer.Services.Data.Implementations;
    using CarDealer.Web.ViewModels.InputModels.Users;
    using CarDealer.Web.ViewModels.Users;

    using Moq;
    using Xunit;

    public class UsersServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CheckIfGetUserByIdMethodReturnsTheCorrectUser()
        {
            var service = await this.GetUsersService();

            var user = await service.GetUserById("1");

            Assert.Equal("UserName", user.UserName);
            Assert.Equal("FirstName", user.FirstName);
            Assert.Equal("LastName", user.LastName);
            Assert.Equal("1234567890", user.PhoneNumber);
            Assert.Equal("email@gmail.com", user.Email);
        }

        [Fact]
        public async Task CheckIfUpdateUserInfoMethodWorksCorrectly()
        {
            var service = await this.GetUsersService();

            var inputModel = new UserInputModel
            {
                UserName = "NewUsername",
                FirstName = "NewFirstName",
                LastName = "NewLastName",
                Email = "NewEmail",
                PhoneNumber = "NewPhoneNumber",
            };

            var updatedUser = await service.UpdateUserInfo("2", inputModel);

            Assert.Equal(inputModel.UserName, updatedUser.UserName);
            Assert.Equal(inputModel.FirstName, updatedUser.FirstName);
            Assert.Equal(inputModel.LastName, updatedUser.LastName);
            Assert.Equal(inputModel.PhoneNumber, updatedUser.PhoneNumber);
            Assert.Equal(inputModel.Email, updatedUser.Email);
        }

        private async Task<IUsersService> GetUsersService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var repository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);

            var service = new UsersService(repository);

            return service;
        }
    }
}
