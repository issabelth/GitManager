using GitAPI.Exceptions;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{

    public class GitClient
    {

        public string BaseClientAddress;
        public string BaseIssuesAddress;
        
        public GitClient()
        {
        }

        private HttpRequestMessage GetReadyToRequest(HttpClient httpClient, HttpMethod methodType, string apiPath, string json = "")
        {
            httpClient.BaseAddress = new Uri(this.BaseClientAddress);
            var request = new HttpRequestMessage(methodType, apiPath);

            switch (HostData.Host)
            {
                case HostData.HostNameEnum.Github:
                    {
                        request.Headers.Add("Accept", "application/vnd.github+json");
                        request.Headers.Add("Authorization", $"Bearer {GetToken()}");
                        request.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
                        request.Headers.Add("User-Agent", "issabelth");
                        break;
                    }
                case HostData.HostNameEnum.Gitlab:
                    {
                        request.Headers.Add("Accept", "application/json");
                        request.Headers.Add("PRIVATE-TOKEN", $"{GetToken()}");
                        break;
                    }
            }

            if (!string.IsNullOrWhiteSpace(json))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json"); // Content-Type
            }

            return request;
        }

        public async Task<string> SendRequest(HttpMethod methodType, string apiPath, string json = "")
        {
            using (var client = new HttpClient())
            {
                var request = GetReadyToRequest(httpClient: client, methodType: methodType, apiPath: apiPath, json: json);
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new ResponseException(response.StatusCode);
                }
            }
        }

        private string GetToken()
        { 
            if (string.IsNullOrWhiteSpace(AppFile.AppFilePath))
            {
                throw new Exception("Problem with the options file. Check your file and try again.");
            }

            var appOpts = ApiOptions.FromFile(AppFile.AppFilePath);

            if (appOpts == null ||
                string.IsNullOrWhiteSpace(appOpts.Token))
            {
                throw new Exception("Problem with loading token from file. Check your file and try again.");
            }

            return appOpts.Token;
        }

    }
}
