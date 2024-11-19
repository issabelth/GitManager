using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PostMethods
    {

        public static async Task<string> PostIssue(GitClient client, string title, string description)
        {
            string json = string.Empty;

            if (HostData.Host == HostData.HostNameEnum.Github)
            {
                json = JsonConvert.SerializeObject(new
                {
                    title = title,
                    body = description,
                });
            }
            else if (HostData.Host == HostData.HostNameEnum.Gitlab)
            {
                json = JsonConvert.SerializeObject(new
                {
                    title = title,
                    description = description,
                });
            }

            return await client.SendRequest(methodType: HttpMethod.Post, apiPath: $"{client.NewIssueAddress}", json: json);
        }

    }
}
