namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    public interface ICountriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
