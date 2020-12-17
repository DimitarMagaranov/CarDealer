namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class GearboxesService : IGearboxesService
    {
        private readonly IGenericsService genericsService;
        private readonly IRepository<Gearbox> gearboxesRepository;

        public GearboxesService(IRepository<Gearbox> gearboxesRepository)
        {
            this.gearboxesRepository = gearboxesRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync()
        {
            var gearBoxes = new List<KeyValuePair<string, string>>();

            gearBoxes = await this.gearboxesRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Id.ToString()))
                .ToListAsync();

            gearBoxes.Insert(0, new KeyValuePair<string, string>("Select gearbox", null));

            return gearBoxes;
        }
    }
}
