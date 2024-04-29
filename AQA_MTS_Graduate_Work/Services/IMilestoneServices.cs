using AQA_MTS_Graduate_Work.Models;
using System.Net;

namespace AQA_MTS_Graduate_Work.Services;

public interface IMilestoneServices
{
    Task<Milestone> GetMilestone(string milestoneId);
    Task<Milestone> AddMilestone(string projectId, Milestone milestone);
    Task<Milestone> UpdateMilestone(Milestone milestone);
    HttpStatusCode DeleteMilestone(string milestoneId);
}