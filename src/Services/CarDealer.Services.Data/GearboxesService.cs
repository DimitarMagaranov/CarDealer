namespace CarDealer.Services.Data
{
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GearboxesService : IGearboxesService
    {
        private readonly IRepository<Gearbox> gearboxesRepository;

        public GearboxesService(IRepository<Gearbox> gearboxesRepository)
        {
            this.gearboxesRepository = gearboxesRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync()
        {
            var gearboxes = await this.gearboxesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToListAsync();

            var data = gearboxes.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select gearbox"));

            return data;
        }
    }
}
