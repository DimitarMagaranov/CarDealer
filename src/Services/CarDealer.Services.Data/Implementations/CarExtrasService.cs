﻿namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class CarExtrasService : ICarExtrasService
    {
        private readonly IRepository<CarExtra> carExtrasRepository;
        private readonly IExtrasService extrasService;

        public CarExtrasService(
            IRepository<CarExtra> carExtrasRepository,
            IExtrasService extrasService)
        {
            this.carExtrasRepository = carExtrasRepository;
            this.extrasService = extrasService;
        }

        public async Task<IEnumerable<string>> GetExtrasByCarId(int carId)
        {
            var extraIds = await this.carExtrasRepository.AllAsNoTracking().Where(x => x.CarId == carId).Select(x => x.ExtraId).ToListAsync();
            var extrasDb = await this.extrasService.GetAllExtras();
            var carExtras = new List<string>();
            if (extraIds.Count > 0)
            {
                foreach (var extra in extrasDb)
                {
                    if (extraIds.Contains(extra.Id))
                    {
                        carExtras.Add(extra.Name);
                    }
                }
            }

            return carExtras;
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
