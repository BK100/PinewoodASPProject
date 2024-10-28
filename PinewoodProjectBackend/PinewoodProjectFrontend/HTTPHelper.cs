using PinewoodProjectFrontend.Models;
using System.Text;
using System.Text.Json;

namespace PinewoodProjectFrontend
{
    public static class HTTPHelper
    {
        public async static Task<List<CustomerProfile>> LoadTableData(HttpClient client) 
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://localhost:7202/GetCustomerData");

            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var resultArray = JsonSerializer.Deserialize<List<CustomerProfile>>(result);

            return resultArray;
        }

        public async static void DeleteRecord(HttpClient client, int id)
        {
            var requestData = JsonSerializer.Serialize(id);
            var httpRequestBody = new StringContent(requestData, Encoding.UTF8, "application/json");   

            var result = await client.PostAsync("https://localhost:7202/DeleteRecord", httpRequestBody);
        }

        public async static void AddRecord(HttpClient client, CustomerProfile profile)
        {
            var requestData = JsonSerializer.Serialize(profile);
            var httpRequestBody = new StringContent(requestData, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("https://localhost:7202/AddRecord", httpRequestBody);
        }

        public async static void UpdateRecord(HttpClient client, CustomerProfile profile)
        {
            var requestData = JsonSerializer.Serialize(profile);
            var httpRequestBody = new StringContent(requestData, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("https://localhost:7202/UpdateRecord", httpRequestBody);
        }
    }
}
