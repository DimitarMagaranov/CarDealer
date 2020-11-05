using System.Collections;
using System.Collections.Generic;

namespace CarDealer.Models.CarModels
{
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
