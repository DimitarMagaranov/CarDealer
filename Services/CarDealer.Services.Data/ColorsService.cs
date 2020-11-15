namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;

    public class ColorsService : IColorsService
    {
        private readonly IRepository<Color> colorsRepository;

        public ColorsService(IRepository<Color> colorsRepository)
        {
            this.colorsRepository = colorsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            var data = this.colorsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select color"));

            return data;
        }
    }
}
