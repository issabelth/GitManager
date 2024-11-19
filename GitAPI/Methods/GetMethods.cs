using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class GetMethods
    {

        public static async Task<string> GetIssues_GiHub(GitClient client)
        {
            return await client.SendRequest(methodType: HttpMethod.Get, apiPath: $"{client.BaseIssuesAddress}");
        }

        public static async Task<string> GetIssues_GitLab(GitClient client, string projectId, string addParameters = "")
        {
            return await client.SendRequest(methodType: HttpMethod.Get, apiPath: $"{client.BaseProjectsAddress}/{projectId}/issues{addParameters}");
        }

        public static async Task<string> GetIssue_GitHub(GitClient client, string issueId)
        {
            return await client.SendRequest(methodType: HttpMethod.Get, apiPath: $"{client.BaseIssuesAddress}/{issueId}");
        }

        public static async Task<string> GetIssue_GitLab(GitClient client, string issueId, string projectId)
        {
            return await client.SendRequest(methodType: HttpMethod.Get, apiPath: $"{client.BaseProjectsAddress}/{projectId}/issues/{issueId}");
        }

        public static async Task<string> GetProjectByName_GitLab(GitClient client, string projectName)
        {
            return await client.SendRequest(methodType: HttpMethod.Get, apiPath: $"{client.BaseProjectsAddress}?search={projectName}");
        }


    }
}
