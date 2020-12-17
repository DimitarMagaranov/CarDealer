namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;

    public class GenericsService : IGenericsService
    {
        private readonly IConfiguration configuration;

        public GenericsService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync(string entity)
        {
            var data = new List<KeyValuePair<string, string>>();

            string queryString = $"SELECT [Id],[Name] FROM[CarDealer].[dbo].[{entity}]";

            string conStr = ConfigurationExtensions.GetConnectionString(this.configuration, "DefaultConnection");

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(new KeyValuePair<string, string>(reader[1].ToString(), reader[0].ToString()));
                    }
                }
            }

            data.Insert(0, new KeyValuePair<string, string>("Please make a selection", null));

            return data;
        }
    }
}
