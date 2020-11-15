﻿namespace CarDealer.Services.Data
{
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using System.Collections.Generic;

    public interface ICountriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
