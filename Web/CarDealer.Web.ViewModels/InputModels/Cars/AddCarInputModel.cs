namespace CarDealer.Web.ViewModels.InputModels.Cars
{
    using System;

    public class AddCarInputModel
    {
        public int MakeId { get; set; }

        public int CategoryId { get; set; }

        public int FuelTypeId { get; set; }

        public int EngineSize { get; set; }

        public int EuroStandartId { get; set; }

        public int GearboxId { get; set; }

        public int ColorId { get; set; }

        public string Doors { get; set; }

        public string State { get; set; }

        public int Mileage { get; set; }

        public DateTime ManufactureDate { get; set; }
    }
}
