using System.Collections.Generic;

namespace CarDealer.Models.CarModels
{
    public class Category
    {
        public Category()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
