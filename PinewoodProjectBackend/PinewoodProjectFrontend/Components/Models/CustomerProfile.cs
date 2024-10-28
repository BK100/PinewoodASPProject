using PinewoodProjectFrontend.Models.Enums;
using System.Text.Json.Serialization;

namespace PinewoodProjectFrontend.Models
{

    // Model for customer profile data container. Ideally this would be immplemented and consumed through a package reference to avoid reuse of models in different services

    public class CustomerProfile
    {
        [JsonPropertyName("customerID")]
        public int CustomerID { get; set; }

        [JsonPropertyName("dateRegistered")]
        public DateOnly DateRegistered { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [JsonPropertyName("productType")]
        public ProductType ProductType { get; set; } = ProductType.Commercial;

        [JsonPropertyName("enableMarketing")]
        public bool EnableMarketing { get; set; } = false;

        [JsonPropertyName("originalID")]
        public int? OriginalID { get; set; }
    }
}
