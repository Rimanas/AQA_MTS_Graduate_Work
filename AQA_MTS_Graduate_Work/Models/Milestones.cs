using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AQA_MTS_Graduate_Work.Models;

public class Milestones
{
    [JsonPropertyName("offset")] public int Offset { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; }
    [JsonPropertyName("size")] public int Size { get; set; }
    [JsonPropertyName("_links")] public Links Links { get; set; }
    [JsonPropertyName("milestones")] public Milestone[] MilestonesList { get; set; }
}