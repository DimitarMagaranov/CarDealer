namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountriesService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync();
    }
}
