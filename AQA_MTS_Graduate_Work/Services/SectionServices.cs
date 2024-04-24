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

    public Task<Section> GetSection(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/get_section/{section_id}")
            .AddUrlSegment("project_id", projectId);

        return _client.ExecuteAsync<Section>(request);
    }
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}