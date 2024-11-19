using GitAPI;
using System;
using static GitAPI.HostData;

namespace GitManager
{
    internal static class AppClient
    {

        public static GitClient Client;

        public static void CreateClient(string ownerName, string repoName)
        {
            switch (Host)
            {
                case HostNameEnum.Github:
                    {
                        Client = new GitClient();
                        Client.BaseClientAddress = @"https://api.github.com/";
                        Client.BaseIssuesAddress = $"repos/{ownerName}/{repoName}/issues";

                        break;
                    }
                case HostNameEnum.Gitlab:
                    {
                        Client = new GitClient();
                        Client.BaseClientAddress = @"https://gitlab.com/api/v4/";
                        Client.BaseIssuesAddress = $"issues";
                        break;
                    }
            }
        }

    }
}
