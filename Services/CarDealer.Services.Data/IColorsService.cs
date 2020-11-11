namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    public interface IColorsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
