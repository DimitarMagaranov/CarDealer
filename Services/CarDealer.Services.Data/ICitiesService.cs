namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICitiesService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairs(int countryId);
    }
}
