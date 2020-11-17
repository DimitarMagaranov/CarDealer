namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class MakesService : IMakesService
    {
        private readonly IRepository<Make> makesRepository;

        public MakesService(IRepository<Make> makesRepository)
        {
            this.makesRepository = makesRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairs()
        {
            var makes = await this.makesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToListAsync();

            var data = makes.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select brand"));

            return data;
        }
    }
}
