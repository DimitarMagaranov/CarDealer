namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarExtrasService
    {
        Task<IEnumerable<string>> GetExtrasByCarId(int carId);

        Task AddExtrasToDbAsync(int carId, IEnumerable<int> extras);
    }
}
