using GitAPI;
using GitAPI.Methods;
using GitAPI.Schemas;
using System;
using System.Threading.Tasks;

namespace GitManager.Methods
{
    internal static class IssuesMethods
    {

        public static void SaveIssue(GitClient client, Issue issue)
        {
            if (issue.Number.HasValue)
            {
                UpdateIssue(
                    client: client,
                    issueNumber: issue.Number.Value,
                    title: issue.Title,
                    description: issue.Body);
            }
            else
            {
                CreateIssue(
                    client: client,
                    title: issue.Title,
                    description: issue.Body);
            }
        }

        private static void CreateIssue(GitClient client, string title, string description)
        {
            PostMethods.PostIssue(client: client, title: title, description: description);
        }
        private static void UpdateIssue(GitClient client, Int64 issueNumber, string title, string description)
        {
            PatchMethods.PatchIssue(client: client, issueNumber: issueNumber, title: title, description: description);
        }

    }
}