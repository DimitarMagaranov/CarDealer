namespace CarDealer.Services.Data.Implementations
{
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;

    public class ModelsService : IModelsService
    {
        private readonly IRepository<Model> modelsRepository;

        public ModelsService(
            IRepository<Model> modelsRepository)
        {
            this.modelsRepository = modelsRepository;
        }

        public ModelViewModel GetById(int id)
        {
            var model = this.modelsRepository.AllAsNoTracking().First(x => x.Id == id);

            return new ModelViewModel { Id = model.Id, Name = model.Name };
        }
    }
}
