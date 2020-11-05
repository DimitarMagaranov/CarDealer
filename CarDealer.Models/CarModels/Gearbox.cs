﻿using System.Collections.Generic;

namespace CarDealer.Models.CarModels
{
    public class Gearbox
    {
        public Gearbox()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
