namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    public interface IGearboxesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
