namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;

    public class CarExtrasService : ICarExtrasService
    {
        private readonly IRepository<CarExtra> carExtrasRepository;

        public CarExtrasService(IRepository<CarExtra> carExtrasRepository)
        {
            this.carExtrasRepository = carExtrasRepository;
        }

        public IEnumerable<int> GetExtras(int carId)
        {
            return this.carExtrasRepository.AllAsNoTracking().Where(x => x.CarId == carId).Select(x => x.ExtraId).ToList();
        }

        public async Task AddExtrasToDbAsync(int carId, IEnumerable<int> extras)
        {
            if (extras == null)
            {
                return;
            }

            foreach (var extra in extras)
            {
                var carExtra = new CarExtra()
                {
                    CarId = carId,
                    ExtraId = extra,
                };

                await this.carExtrasRepository.AddAsync(carExtra);
                await this.carExtrasRepository.SaveChangesAsync();
            }
        }
    }
}
