
using System.Text.Json.Serialization;

namespace AQA_MTS_Graduate_Work.Enums;
public class Case
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("estimate")] public string? Estimate { get; set; }
    [JsonPropertyName("priority_id")] public int? PriorityId { get; set; }