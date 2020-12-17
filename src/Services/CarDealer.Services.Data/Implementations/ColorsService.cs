namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class ColorsService : IColorsService
    {
        private readonly IRepository<Color> colorsRepository;

        public ColorsService(IRepository<Color> colorsRepository)
        {
            this.colorsRepository = colorsRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync()
        {
            var colors = new List<KeyValuePair<string, string>>();

            colors = await this.colorsRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Id.ToString()))
                .ToListAsync();

            colors.Insert(0, new KeyValuePair<string, string>("Select color", null));

            return colors;
        }
    }
}
