using System.Text.Json.Serialization;

namespace AQA_MTS_Graduate_Work.Models
{
    public class Milestone
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        //[JsonPropertyName("completed_on")] public DateTime CompletedOn { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        //[JsonPropertyName("due_on")] public DateTime DueOn { get; set; }
        [JsonPropertyName("id")] public int ID { get; set; }
        //[JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }
        //[JsonPropertyName("is_started")] public bool IsStarted { get; set; }
        //[JsonPropertyName("name")] public string ProjectName { get; set; }
        //[JsonPropertyName("parent_id")] public int ParentId { get; set; }
        [JsonPropertyName("project_id")] public int ProjectId { get; set; }
        [JsonPropertyName("refs")] public string Refs { get; set; }
        //[JsonPropertyName("start_on")] public DateTime StartOn { get; set; }
        //[JsonPropertyName("started_on")] public DateTime StartedOn { get; set; }
        //[JsonPropertyName("url")] public string URL { get; set; }
    }
}