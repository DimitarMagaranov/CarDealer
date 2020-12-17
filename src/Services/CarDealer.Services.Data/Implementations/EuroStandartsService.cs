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

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync()
        {
            var euroStandarts = new List<KeyValuePair<string, string>>();

            euroStandarts = await this.euroStandartsRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Id.ToString()))
                .ToListAsync();

            euroStandarts.Insert(0, new KeyValuePair<string, string>("Select euro standart", null));

            return euroStandarts;
        }
    }
}
