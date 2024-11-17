using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PostMethods
    {

        public static async Task<string> GetIssues()
        {
            string owner = "issabelth";
            string repo = "GitManager";
            return await GitClient.SendRequest(methodType: HttpMethod.Get, apiPath: $"repos/{owner}/{repo}/issues");
        }


    }
}
