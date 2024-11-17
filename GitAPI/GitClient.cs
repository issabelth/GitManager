using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{
    public class GitClient
    {

        public HttpClient Client;

        public GitClient()
        {
            this.Client = CreateClient();
        }

        private HttpClient CreateClient()
        {
            return new HttpClient()
            {
                BaseAddress = new Uri(@"https://api.github.com/"),
            };
        }

        private HttpRequestMessage GetReadyToRequest(HttpMethod methodType, string apiPath, string json = "")
        {
            var request = new HttpRequestMessage(methodType, apiPath);
            request.Headers.Add("Accept", "application/vnd.github+json");
            //request.Headers.Add("Accept", "application/json");
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
            GitClient gitClient = new GitClient();

            var request = gitClient.GetReadyToRequest(methodType: methodType, apiPath: apiPath, json: json);
            var response = await gitClient.Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                // logger?
                //Console.WriteLine($"Error {response.StatusCode}: {response.ReasonPhrase}");
                throw new Exception($"Error {response.StatusCode}: {response.ReasonPhrase}");
            }
        }

        static string GetToken()
        {
            string filePath = @"D:\tokenFile.txt";

            try
            {
                // Read the contents of the file
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
