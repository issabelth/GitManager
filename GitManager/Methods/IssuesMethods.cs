using GitAPI.Methods;
using GitAPI.Schemas;
using System;
using System.Threading.Tasks;

namespace GitManager.Methods
{
    internal static class IssuesMethods
    {

        public static async void SaveIssue(Issue issue)
        {
            if (issue.Number.HasValue)
            {
                await UpdateIssue(
                    issueNumber: issue.Number.Value,
                    title: issue.Title,
                    description: issue.Body);
            }
            else
            {
                await CreateIssue(
                    title: issue.Title,
                    description: issue.Body);
            }
        }

        private static async Task<string> CreateIssue(string title, string description)
        {
            return await PostMethods.PostIssue(title: title, description: description);
        }
        private static async Task<string> UpdateIssue(Int64 issueNumber, string title, string description)
        {
            return await PatchMethods.PatchIssue(issueNumber: issueNumber, title: title, description: description);
        }

    }
}