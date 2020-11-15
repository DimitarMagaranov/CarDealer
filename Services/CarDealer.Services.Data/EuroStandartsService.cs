namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;

    public class EuroStandartsService : IEuroStandartsService
    {
        private readonly IRepository<EuroStandart> euroStandartsRepository;

        public EuroStandartsService(IRepository<EuroStandart> euroStandartsRepository)
        {
            this.euroStandartsRepository = euroStandartsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            var data = this.euroStandartsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select euro standart"));

            return data;
        }
    }
}
