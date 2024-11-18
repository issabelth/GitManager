using GitAPI.Exceptions;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{

    public static class GitClient
    {

        public static HttpClient Client = new HttpClient()
        {
            BaseAddress = new Uri(@"https://api.github.com/"),
        };

        public static string BaseIssuesAddress = $"repos/{GitData.GitOwnerName}/{GitData.GitRepoName}/issues";

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

        public static async Task<string> SendRequest(HttpMethod methodType, string apiPath, string json = "")
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
            string filePath = @"D:\tokenFile.txt";

            try
            {
                return File.ReadAllText(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified file was not found.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while reading file: {ex.Message}");
            } 
            return null;
        }

    }
}
