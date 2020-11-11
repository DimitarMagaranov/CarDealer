using System.Collections;
using System.Collections.Generic;

namespace CarDealer.Services.Data
{
    public interface IEuroStandartsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
