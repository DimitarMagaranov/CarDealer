namespace CarDealer.Services.Data
{
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Services.Data.Dtos;
    using System.Linq;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Sale> salesRepository;
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IRepository<Make> makesRepository;
        private readonly IRepository<Category> categoriesRepository;

        public GetCountsService(
            IDeletableEntityRepository<Sale> salesRepository,
            IDeletableEntityRepository<Car> carsRepository,
            IRepository<Make> makesRepository,
            IRepository<Category> categoriesRepository)
        {
            this.salesRepository = salesRepository;
            this.carsRepository = carsRepository;
            this.makesRepository = makesRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                SalesCount = this.salesRepository.All().Count(),
                CarsCount = this.carsRepository.All().Count(),
                MakesCount = this.makesRepository.All().Count(),
                CategoriesCount = this.categoriesRepository.All().Count(),
            };

            return data;
        }
    }
}
