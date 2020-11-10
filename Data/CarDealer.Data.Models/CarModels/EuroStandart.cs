namespace CarDealer.Data.Models.CarModels
{
    using System.Collections.Generic;

    public class EuroStandart
    {
        public EuroStandart()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
