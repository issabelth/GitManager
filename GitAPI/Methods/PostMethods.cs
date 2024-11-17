using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PostMethods
    {

        public static async Task<string> PostIssue(string title, string description)
        {
            string owner = "issabelth";
            string repo = "GitManager";

            var json = JsonConvert.SerializeObject(new
            {
                title = title,
                body = description,
            });

            return await GitClient.SendRequest(methodType: HttpMethod.Post, apiPath: $"repos/{owner}/{repo}/issues", json: json);
        }


    }
}
