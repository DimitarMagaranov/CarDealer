namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.Cities;

    public interface ICitiesService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync(int countryId);

        Task<string> GetCityNameBySaleId(int id);
    }
}
