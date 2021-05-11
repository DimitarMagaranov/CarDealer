namespace CarDealer.Services.Data.Implementations
{
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;

    using Microsoft.EntityFrameworkCore;

    public class ModelsService : IModelsService
    {
        private readonly IRepository<Model> modelsRepository;
        private readonly IDeletableEntityRepository<Car> carsRepository;

        public ModelsService(
            IRepository<Model> modelsRepository,
            IDeletableEntityRepository<Car> carsRepository)
        {
            this.modelsRepository = modelsRepository;
            this.carsRepository = carsRepository;
        }

        public async Task<ModelViewModel> GetById(int id)
        {
            var model = await this.modelsRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return new ModelViewModel { Id = model.Id, Name = model.Name };
        }

        public async Task<string> GetModelNameByCarId(int id)
        {
            var car = await this.carsRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            var model = await this.modelsRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == car.ModelId);

            return model.Name;
        }
    }
}
