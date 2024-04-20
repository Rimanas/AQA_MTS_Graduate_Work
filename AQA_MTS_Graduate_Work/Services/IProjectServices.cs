using AQA_MTS_Graduate_Work.Models;
using System.Net;

namespace AQA_MTS_Graduate_Work.Services;
public interface IProjectServices
{
    Task<Project> GetProject(string projectId);
    Task<Projects> GetProjects();
    Task<Project> AddProject(Project project);
    Task<Project> UpdateProject(Project project);
    HttpStatusCode DeleteProject(string projectId);
}