﻿namespace CarDealer.Web.ViewModels.InputModels.Cars
{
    using System.Collections.Generic;

    public class AddCarInputModel : BaseCarInputModel
    {
        public IEnumerable<int> CarExtras { get; set; }
    }
}
