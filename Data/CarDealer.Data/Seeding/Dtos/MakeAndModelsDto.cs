namespace CarDealer.Data.Seeding.Dtos
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class MakeAndModelsDto
    {
        public MakeAndModelsDto()
        {
            this.Models = new List<string>();
        }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("models")]
        public ICollection<string> Models { get; set; }
    }
}
