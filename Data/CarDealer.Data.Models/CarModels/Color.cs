namespace CarDealer.Data.Models.CarModels
{
    using System.Collections.Generic;

    public class Color
    {
        public Color()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
