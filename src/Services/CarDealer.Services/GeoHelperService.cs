namespace CarDealer.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GeoHelperService : IGeoHelperService
    {
        private readonly HttpClient httpClient;

        public GeoHelperService()
        {
            this.httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5),
            };
        }

        public async Task<string> GetGeoInfo()
        {
            ////I have already created this function under GeoInfoProvider class.
            var ipAddress = await this.GetIPAddress();

            //// When geting ipaddress, call this function and pass ipaddress as given below
            var response = await this.httpClient.GetAsync($"http://api.ipstack.com/" + ipAddress + $"?access_key=382ab06a983e606edcc4b8813c20a121"); ////the key is from ipstack.com

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }

            return null;
        }

        public async Task<string> GetIPAddress()
        {
            var ipAddress = await this.httpClient.GetAsync($"http://ipinfo.io/ip");
            if (ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }

            return string.Empty;
        }
    }
}
