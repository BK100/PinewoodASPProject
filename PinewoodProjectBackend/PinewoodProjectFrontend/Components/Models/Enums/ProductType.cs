using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinewoodProjectFrontend.Models.Enums
{
    // Enums for product types, with string enum converter for preservation of value name through JSON serialization

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductType
    {
        Commercial = 1,
        Business = 2,
        Insurance = 3,
        Miscellaneous = 4 
    }
}
