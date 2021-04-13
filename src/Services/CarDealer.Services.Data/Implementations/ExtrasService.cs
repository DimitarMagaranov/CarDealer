namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.Cars.CarExtras;

    public class ExtrasService : IExtrasService
    {
        private readonly IRepository<Extra> extrasRepository;

        public ExtrasService(IRepository<Extra> extrasRepository)
        {
            this.extrasRepository = extrasRepository;
        }

        public IEnumerable<ExtraViewModel> GetAllExtras()
        {
            return this.extrasRepository.AllAsNoTracking()
                .Select(x => new ExtraViewModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                }).ToList();
        }
    }
}
