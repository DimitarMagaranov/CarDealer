namespace CarDealer.Services.Data
{
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountriesService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairs();
    }
}
