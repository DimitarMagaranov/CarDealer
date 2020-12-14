namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarMakes;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class MakesService : IMakesService
    {
        private readonly IRepository<Make> makesRepository;
        private readonly IGenericsService genericsService;

        public MakesService(
            IRepository<Make> makesRepository,
            IGenericsService genericsService)
        {
            this.makesRepository = makesRepository;
            this.genericsService = genericsService;
        }

        public async Task<IEnumerable<MakeViewModel>> GetMakeWithModelsAsync(int id)
        {
            var data = await this.makesRepository.All()
                .Where(x => x.Id == id)
                .Include(x => x.Models)
                .ToListAsync();

            var viewModelList = data.Select(x => new MakeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Models = x.Models.Select(m => new ModelViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                }),
            });

            return viewModelList;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            return await this.genericsService.GetAllAsSelectListItemsAsync("Makes");
        }
    }
}
