using AQA_MTS_Graduate_Work.Clients;
using AQA_MTS_Graduate_Work.Models;
using RestSharp;
using System.Net;

namespace AQA_MTS_Graduate_Work.Services;
public class MilestoneServices : IMilestoneServices, IDisposable
{
    private readonly RestClientExtended _client;

    public MilestoneServices(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Milestone> GetMilestone(string milestoneId)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestone/{milestone_id}")
            .AddUrlSegment("milestone_id", milestoneId);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestone> AddMilestone(string projectId, Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/add_milestone/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody(milestone);

        return _client.ExecuteAsync<Milestone>(request);
    }
    public Task<RestResponse> AddMilestoneResponse(string projectId, Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/add_milestone/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody(milestone);

        return _client.ExecuteAsync(request);
    }

    public Task<Milestone> UpdateMilestone(Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/update_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestone.ID)
            .AddJsonBody(milestone);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public HttpStatusCode DeleteMilestone(string milestoneId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestoneId)
            .AddJsonBody("{}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}