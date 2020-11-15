namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    public interface ICitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs(int countryId);
    }
}
