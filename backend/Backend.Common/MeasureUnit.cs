using System.Text.Json.Serialization;

namespace backend.Core.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MeasureUnit
    {
        Kilogram = 0,
        Gram = 1,
        Decigram = 2,
        Liter = 3,
        Deciliter = 4,
        Mililiter = 5
    }
}
