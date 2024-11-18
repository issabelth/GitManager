using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class GetMethods
    {

        public static async Task<string> GetIssues()
        {
            return await GitClient.SendRequest(methodType: HttpMethod.Get, apiPath: $"{GitClient.BaseIssuesAddress}");
        }

        public static async Task<string> GetIssue(string issueId)
        {
            return await GitClient.SendRequest(methodType: HttpMethod.Get, apiPath: $"{GitClient.BaseIssuesAddress}/{issueId}");
        }


    }
}
