using GitAPI;

namespace GitManager
{
    internal static class AppClient
    {
        public static GitClient Client;

        public static void CreateClient(string ownerName, string repoName)
        {
            Client = new GitClient(
                gitOwnerName: ownerName,
                gitRepoName: repoName);
        }

    }
}
