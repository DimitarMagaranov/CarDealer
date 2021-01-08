namespace CarDealer.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class AddCarViewModel : BaseCarViewModel
    {
        public IEnumerable<int> CarExtras { get; set; }
    }
}
