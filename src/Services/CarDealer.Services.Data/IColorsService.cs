﻿namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IColorsService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync();
    }
}
