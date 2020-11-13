﻿namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    public interface IFuelTypesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}