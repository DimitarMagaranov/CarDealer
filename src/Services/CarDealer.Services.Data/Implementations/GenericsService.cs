namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Microsoft.Data.SqlClient;

    public class GenericsService : IGenericsService
    {
        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync(string entity)
        {
            List<SelectListItem> data = new List<SelectListItem>();

            string queryString = $"SELECT [Id],[Name] FROM[CarDealer].[dbo].[{entity}]";

            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-C92LTDN\\SQLEXPRESS;Database=CarDealer;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(new SelectListItem() { Text = reader[1].ToString(), Value = reader[0].ToString() });
                    }
                }
            }

            data.Insert(0, new SelectListItem() { Text = $"Select ...", Value = null });

            return data;
        }
    }
}
