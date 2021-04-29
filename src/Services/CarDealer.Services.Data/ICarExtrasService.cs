namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.Cars.CarExtras;

    public interface ICarExtrasService
    {
        IEnumerable<string> GetExtrasByCarId(int carId);

        Task AddExtrasToDbAsync(int carId, IEnumerable<int> extras);
    }
}
