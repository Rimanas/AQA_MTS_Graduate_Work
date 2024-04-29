using System.Text.Json.Serialization;

namespace AQA_MTS_Graduate_Work.Models;
public class Links
{
    [JsonPropertyName("next")] public string Next { get; set; }
    [JsonPropertyName("prev")] public string Prev { get; set; }
}
