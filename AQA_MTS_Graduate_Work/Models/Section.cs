using System.Text.Json.Serialization;

namespace AQA_MTS_Graduate_Work.Models;
public class Section
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("parent_id")] public int ParentId { get; set; }
    [JsonPropertyName("description")] public int Description { get; set; }
}