namespace CarDealer.Web.ViewModels.Dashboard
{
    using System;
    using System.Collections.Generic;

    using CarDealer.Web.ViewModels.Sales;

    public class DashboardViewModel
    {
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public DateTime UserCreatedOn { get; set; }

        public string UserCreatedOnAsString => $"{this.UserCreatedOn.Day}/{this.UserCreatedOn.Month}/{this.UserCreatedOn.Year}";

        public List<SaleViewModel> Sales { get; set; }
    }
}
