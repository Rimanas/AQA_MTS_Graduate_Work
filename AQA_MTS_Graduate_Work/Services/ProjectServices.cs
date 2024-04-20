﻿using AQA_MTS_Graduate_Work.Clients;
using AQA_MTS_Graduate_Work.Models;
using RestSharp;
using System.Net;

namespace AQA_MTS_Graduate_Work.Services;
public class ProjectServices : IProjectServices, IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectServices(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Project> GetProject(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
            .AddUrlSegment("project_id", projectId);

        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Projects> GetProjects()
    {
        var request = new RestRequest("index.php?/api/v2/get_projects");

        var projects = _client.ExecuteAsync<Projects>(request);
        return projects;
    }

    public Task<Project> AddProject(Project project)
    {
        var request = new RestRequest("index.php?/api/v2/add_project", Method.Post)
            .AddJsonBody(project);

        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Project> UpdateProject(Project project)
    {
        var request = new RestRequest("index.php?/api/v2/update_project/{project_id}", Method.Post)
            .AddUrlSegment("project_id", project.Id)
            .AddJsonBody(project);

        return _client.ExecuteAsync<Project>(request);
    }

    public HttpStatusCode DeleteProject(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_project/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody("{}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}