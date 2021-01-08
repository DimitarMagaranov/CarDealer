namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarMakes;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class MakesService : IMakesService
    {
        private readonly IRepository<Make> makesRepository;

        public MakesService(IRepository<Make> makesRepository)
        {
            this.makesRepository = makesRepository;
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

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync()
        {
            var makes = new List<KeyValuePair<string, string>>();

            makes = await this.makesRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Id.ToString()))
                .ToListAsync();

            makes.Insert(0, new KeyValuePair<string, string>("Select make", null));

            return makes;
        }
    }
}
