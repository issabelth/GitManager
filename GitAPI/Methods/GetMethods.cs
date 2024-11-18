using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class GetMethods
    {

        public static async Task<string> GetIssues()
        {
            string owner = "issabelth";
            string repo = "GitManager";
            return await GitClient.SendRequest(methodType: HttpMethod.Get, apiPath: $"repos/{owner}/{repo}/issues");
        }

        public static async Task<string> GetIssue(string issueId)
        {
            string owner = "issabelth";
            string repo = "GitManager";
            return await GitClient.SendRequest(methodType: HttpMethod.Get, apiPath: $"repos/{owner}/{repo}/issues/{issueId}");
        }


    }
}
