using Allure.NUnit.Attributes;
using AQA_MTS_Graduate_Work.Clients;
using AQA_MTS_Graduate_Work.Models;
using RestSharp;
using System.Net;

namespace AQA_MTS_Graduate_Work.Services;
public class SectionServices : ISectionServices, IDisposable
{
    private readonly RestClientExtended _client;
    public SectionServices(RestClientExtended client)
    {
        _client = client;
    }
    public Task<Section> AddSection(string projectId, Section section)
    {
        var request = new RestRequest("index.php?/api/v2/add_section/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody(section);

        return _client.ExecuteAsync<Section>(request);
    }

    [AllureStep("Get Section By Id")]
    public Task<Section> GetSection(string sectionId)
    {
        var request = new RestRequest("index.php?/api/v2/get_section/{section_id}")
            .AddUrlSegment("section_id", sectionId);

        return _client.ExecuteAsync<Section>(request);
    }
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}