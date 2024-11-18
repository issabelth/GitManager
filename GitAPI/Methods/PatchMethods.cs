using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PatchMethods
    {

        public static async Task<string> PatchIssue(Int64 issueId, string title, string description)
        {
            string owner = "issabelth";
            string repo = "GitManager";

            var json = JsonConvert.SerializeObject(new
            {
                title = title,
                body = description,
            });

            return await GitClient.SendRequest(methodType: new HttpMethod("PATCH"), apiPath: $"repos/{owner}/{repo}/issues/{issueId}", json: json);
        }


    }
}
