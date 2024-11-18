using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PatchMethods
    {

        public static async Task<string> PatchIssue(int issueId, string title, string description)
        {
            string owner = "issabelth";
            string repo = "GitManager";

            var json = JsonConvert.SerializeObject(new
            {
                title = title,
                body = description,
            });

            return await GitClient.SendRequest(methodType: HttpMethod.Put, apiPath: $"repos/{owner}/{repo}/issues/{issueId}", json: json);
        }


    }
}
