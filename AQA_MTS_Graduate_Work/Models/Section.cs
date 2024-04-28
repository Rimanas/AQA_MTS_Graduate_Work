using System.Text.Json.Serialization;
using System.Net;

namespace AQA_MTS_Graduate_Work.Models;
public class Section
{
    [JsonPropertyName("id")] public int Id { get; set; }
    //[JsonPropertyName("section_id")] public int SectionId { get; set; }
    //[JsonPropertyName("suite_id")] public int SuitId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("display_order")] public int? DisplayOrder { get; set; }
    [JsonPropertyName("depth")] public int? Depth { get; set; }
}