namespace CarDealer.Data.Seeding.Dtos
{
    using System.Collections.Generic;

    public class MakeWithModelsDto
    {
        public MakeWithModelsDto()
        {
            this.Models = new List<ModelDto>();
        }

        public string Brand { get; set; }

        public ICollection<ModelDto> Models { get; set; }
    }
}
