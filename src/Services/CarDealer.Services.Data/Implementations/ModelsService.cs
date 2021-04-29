namespace CarDealer.Services.Data.Implementations
{
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;

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

        public ModelViewModel GetById(int id)
        {
            var model = this.modelsRepository.AllAsNoTracking().First(x => x.Id == id);

            return new ModelViewModel { Id = model.Id, Name = model.Name };
        }

        public string GetModelNameByCarId(int id)
        {
            var car = this.carsRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
            var model = this.modelsRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == car.ModelId);

            return model.Name;
        }
    }
}
