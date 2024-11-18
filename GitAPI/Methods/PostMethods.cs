using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PostMethods
    {

        public static async Task<string> PostIssue(string title, string description)
        {
            var json = JsonConvert.SerializeObject(new
            {
                title = title,
                body = description,
            });

            return await GitClient.SendRequest(methodType: HttpMethod.Post, apiPath: $"{GitClient.BaseIssuesAddress}", json: json);
        }

    }
}
