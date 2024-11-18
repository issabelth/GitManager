using GitAPI.Exceptions;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{

    public class GitClient
    {

        public string BaseIssuesAddress;


        public GitClient(string gitOwnerName, string gitRepoName)
        {
            this.BaseIssuesAddress = $"repos/{gitOwnerName}/{gitRepoName}/issues";
        }

        public static HttpClient Client = new HttpClient()
        {
            BaseAddress = new Uri(@"https://api.github.com/"),
        };

        private static HttpRequestMessage GetReadyToRequest(HttpMethod methodType, string apiPath, string json = "")
        {
            var request = new HttpRequestMessage(methodType, apiPath);
            request.Headers.Add("Accept", "application/vnd.github+json");
            request.Headers.Add("Authorization", $"Bearer {GetToken()}");
            request.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
            request.Headers.Add("User-Agent", "issabelth");

            if (!string.IsNullOrWhiteSpace(json))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json"); // Content-Type
            }

            return request;
        }

        public async Task<string> SendRequest(HttpMethod methodType, string apiPath, string json = "")
        {
            var request = GitClient.GetReadyToRequest(methodType: methodType, apiPath: apiPath, json: json);
            var response = await GitClient.Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                throw new ResponseException(response.StatusCode);
            }
        }

        static string GetToken()
        { 
            if (string.IsNullOrWhiteSpace(AppFile.AppFilePath))
            {
                throw new Exception("Problem with the options file. Check your file and try again.");
            }

            var appOpts = AppOptions.FromFile(AppFile.AppFilePath);

            if (appOpts == null ||
                string.IsNullOrWhiteSpace(appOpts.Token))
            {
                throw new Exception("Problem with loading token from file. Check your file and try again.");
            }

            return appOpts.Token;
        }

    }
}
