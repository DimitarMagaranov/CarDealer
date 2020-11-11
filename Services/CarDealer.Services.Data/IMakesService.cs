namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    public interface IMakesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
