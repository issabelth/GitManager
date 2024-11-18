using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class GetMethods
    {

        public static async Task<string> GetIssues(GitClient client)
        {
            return await client.SendRequest(methodType: HttpMethod.Get, apiPath: $"{client.BaseIssuesAddress}");
        }

        public static async Task<string> GetIssue(GitClient client, string issueId)
        {
            return await client.SendRequest(methodType: HttpMethod.Get, apiPath: $"{client.BaseIssuesAddress}/{issueId}");
        }


    }
}
