using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PostMethods
    {
        /// <summary>
        /// Create a new issue in GitHub
        /// </summary>
        public static async Task<string> PostIssue_GitHub(GitClient client, string title, string description)
        {
            string json = JsonConvert.SerializeObject(new
            {
                title = title,
                body = description,
            });

            return await client.SendRequest(methodType: HttpMethod.Post, apiPath: $"{client.NewIssueAddress}", json: json);
        }

        /// <summary>
        /// Create a new issue in GitLab
        /// </summary>
        public static async Task<string> PostIssue_GitLab(GitClient client, string title, string description, string projectId)
        {
            string json = JsonConvert.SerializeObject(new
                {
                    title = title,
                    description = description,
                });

            return await client.SendRequest(methodType: HttpMethod.Post, apiPath: $"{client.BaseProjectsAddress}/{projectId}/issues", json: json);
        }

    }
}
