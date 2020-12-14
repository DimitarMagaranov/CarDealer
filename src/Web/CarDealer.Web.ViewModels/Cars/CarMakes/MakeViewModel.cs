namespace CarDealer.Web.ViewModels.InputModels.Cars.CarMakes
{
    using System.Collections.Generic;

    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;

    public class MakeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ModelViewModel> Models { get; set; }
    }
}
