namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    public interface IRegionsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
