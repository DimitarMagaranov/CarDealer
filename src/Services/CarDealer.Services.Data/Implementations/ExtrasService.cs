namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.Cars.CarExtras;

    using Microsoft.EntityFrameworkCore;

    public class ExtrasService : IExtrasService
    {
        private readonly IRepository<Extra> extrasRepository;

        public ExtrasService(IRepository<Extra> extrasRepository)
        {
            this.extrasRepository = extrasRepository;
        }

        public async Task<IEnumerable<ExtraViewModel>> GetAllExtras()
        {
            return await this.extrasRepository.AllAsNoTracking()
                .Select(x => new ExtraViewModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                }).ToListAsync();
        }
    }
}
