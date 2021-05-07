namespace CarDealer.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using CarDealer.Data;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Services.Mapping;
    using CarDealer.Web.ViewModels;

    using Microsoft.EntityFrameworkCore;

    public class BaseServiceTests
    {
        public BaseServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        protected async Task<ApplicationDbContext> GetUseInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            await this.SeedDbContext(dbContext);

            return dbContext;
        }

        private async Task SeedDbContext(ApplicationDbContext dbContext)
        {
            await dbContext.Sales.AddAsync(this.GetSaleDbModel());
            await dbContext.Cars.AddAsync(this.GetCarDbModel());
            await dbContext.Users.AddAsync(this.GetUserDbModel());
            await dbContext.Images.AddAsync(this.GetImageDbModel());
            await dbContext.Countries.AddAsync(this.GetCountryDbModel());
            await dbContext.Cities.AddAsync(this.GetCityDbModel());
            await dbContext.Makes.AddAsync(this.GetMakeDbModel());
            await dbContext.Models.AddAsync(this.GetModelDbModel());
            await dbContext.EuroStandarts.AddAsync(this.GetEuroStandartDbModel());
            await dbContext.Categories.AddAsync(this.GetCategoryDbModel());
            await dbContext.FuelTypes.AddAsync(this.GetFuelTypeDbModel());
            await dbContext.Gearboxes.AddAsync(this.GetGearboxDbModel());
            await dbContext.Colors.AddAsync(this.GetColorDbModel());
            await dbContext.Extras.AddRangeAsync(this.GetExtrasModels());
            await dbContext.CarExtras.AddRangeAsync(this.GetCarExtrasModels());

            await dbContext.SaveChangesAsync();
        }

        private Sale GetSaleDbModel()
        {
            return new Sale
            {
                Id = 1,
                DaysValid = 20,
                CarId = 1,
                Price = 1,
                CountryId = 1,
                CityId = 1,
                UserId = "1",
                Description = "Description",
                OpensSaleCounter = 1,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
            };
        }

        private Car GetCarDbModel()
        {
            return new Car
            {
                Id = 1,
                MakeId = 1,
                ModelId = 1,
                CategoryId = 1,
                FuelTypeId = 1,
                HorsePower = 1,
                EngineSize = 1,
                Seats = (Seats)1,
                EuroStandartId = 1,
                GearboxId = 1,
                ColorId = 1,
                Doors = (Doors)1,
                State = (State)1,
                Mileage = 1,
                ManufactureDate = DateTime.Now,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
            };
        }

        private Color GetColorDbModel()
        {
            return new Color
            {
                Id = 1,
                Name = "Color",
            };
        }

        private Gearbox GetGearboxDbModel()
        {
            return new Gearbox
            {
                Id = 1,
                Name = "Gearbox",
            };
        }

        private Category GetCategoryDbModel()
        {
            return new Category
            {
                Id = 1,
                Name = "Category",
            };
        }

        private FuelType GetFuelTypeDbModel()
        {
            return new FuelType
            {
                Id = 1,
                Name = "FuelType",
            };
        }

        private EuroStandart GetEuroStandartDbModel()
        {
            return new EuroStandart
            {
                Id = 1,
                Name = "EuroStandart",
            };
        }

        private Image GetImageDbModel()
        {
            return new Image
            {
                Id = "1",
                AddedByUserId = "1",
                SaleId = 1,
                ImageUrl = "https://res.cloudinary.com/dlxqza3bo/image/upload/v1620225901/mloed3ykpjwuavrivfbv.png",
                Extension = "jpg",
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                ResizedImageUrl = "https://res.cloudinary.com/dlxqza3bo/image/upload/v1620225901/mloed3ykpjwuavrivfbv.png",
            };
        }

        private ApplicationUser GetUserDbModel()
        {
            return new ApplicationUser
            {
                Id = "1",
                UserName = "UserName",
                NormalizedUserName = "USERNAME",
                FirstName = "FirstName",
                LastName = "LastName",
                Age = 20,
                CountryId = 1,
                CreatedOn = DateTime.Now,
                Email = "email@abv.bg",
                NormalizedEmail = "EMAIL@ABV.BG",
                EmailConfirmed = true,
                IsDeleted = false,
                PhoneNumber = "123",
                PhoneNumberConfirmed = true,
                ProfileImageUrl = "ProfimeImageUrl",
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };
        }

        private Country GetCountryDbModel()
        {
            return new Country
            {
                Id = 1,
                Name = "Country",
            };
        }

        private City GetCityDbModel()
        {
            return new City
            {
                Id = 1,
                CountryId = 1,
                Name = "City",
            };
        }

        private Make GetMakeDbModel()
        {
            return new Make
            {
                Id = 1,
                Name = "Make",
            };
        }

        private Model GetModelDbModel()
        {
            return new Model
            {
                Id = 1,
                Name = "Model",
                MakeId = 1,
            };
        }

        private List<CarExtra> GetCarExtrasModels()
        {
            return new List<CarExtra>
            {
                new CarExtra
                {
                    Id = 1,
                    CarId = 1,
                    ExtraId = 1,
                },
                new CarExtra
                {
                    Id = 2,
                    CarId = 1,
                    ExtraId = 2,
                },
            };
        }

        private List<Extra> GetExtrasModels()
        {
            return new List<Extra>
            {
                new Extra
                {
                    Id = 1,
                    Name = "Extra1",
                    CreatedOn = DateTime.Now,
                },
                new Extra
                {
                    Id = 2,
                    Name = "Extra2",
                    CreatedOn = DateTime.Now,
                },
            };
        }
    }
}
