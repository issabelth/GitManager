using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PostMethods
    {
        /// <summary>
        /// Create a new issue
        /// </summary>
        public static async Task<string> PostIssue(GitClient client, string title, string description)
        {
            string json = string.Empty;

            switch (HostData.Host)
            {
                case HostData.HostNameEnum.Github:
                    {
                        json = JsonConvert.SerializeObject(new
                        {
                            title = title,
                            body = description,
                        });
                        break;
                    }
                case HostData.HostNameEnum.Gitlab:
                    {
                        json = JsonConvert.SerializeObject(new
                        {
                            title = title,
                            description = description,
                        });
                        break;
                    }
            }

            return await client.SendRequest(methodType: HttpMethod.Post, apiPath: $"{client.NewIssueAddress}", json: json);
        }

    }
}
