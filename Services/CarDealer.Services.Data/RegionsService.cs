namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;

    public class RegionsService : IRegionsService
    {
        private readonly IRepository<Region> regionsRepository;

        public RegionsService(IRepository<Region> regionsRepository)
        {
            this.regionsRepository = regionsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.regionsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
