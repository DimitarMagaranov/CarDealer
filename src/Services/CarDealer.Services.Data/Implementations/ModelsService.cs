namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;

    public class ModelsService : IModelsService
    {
        private readonly IRepository<Model> modelsRepository;
        private readonly IGenericsService genericsService;

        public ModelsService(
            IRepository<Model> modelsRepository,
            IGenericsService genericsService)
        {
            this.modelsRepository = modelsRepository;
            this.genericsService = genericsService;
        }

        public ModelViewModel GetById(int id)
        {
            var model = this.modelsRepository.AllAsNoTracking().First(x => x.Id == id);

            return new ModelViewModel { Id = model.Id, Name = model.Name };
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            return await this.genericsService.GetAllAsSelectListItemsAsync("Models");
        }
    }
}
