namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class EuroStandartsService : IEuroStandartsService
    {
        private readonly IRepository<EuroStandart> euroStandartsRepository;

        public EuroStandartsService(IRepository<EuroStandart> euroStandartsRepository)
        {
            this.euroStandartsRepository = euroStandartsRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync()
        {
            var euroStandarts = new List<KeyValuePair<string, string>>();

            euroStandarts = await this.euroStandartsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Id.ToString()))
                .ToListAsync();

            euroStandarts.Insert(0, new KeyValuePair<string, string>("Select euro standart", null));

            return euroStandarts;
        }
    }
}
