using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PutMethods
    {

        public static async Task<string> PutIssue_GitLab(GitClient client, string projectId, int issueNumber, string title, string description, string state)
        {
            var json = JsonConvert.SerializeObject(new
            {
                title = title,
                description = description,
                state_event = state,
            });

            return await client.SendRequest(methodType: HttpMethod.Put, apiPath: $"{client.BaseProjectsAddress}/{projectId}/issues/{issueNumber}", json: json);
        }


    }
}
