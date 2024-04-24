using AQA_MTS_Graduate_Work.Models;
using System.Net;

namespace AQA_MTS_Graduate_Work.Services;
public interface ISectionServices
{
    Task<Section> AddSection(string projectId);
    Task<Section> GetSection(string sectionId);
}
