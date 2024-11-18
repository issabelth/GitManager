using GitAPI.Methods;
using System;
using System.Threading.Tasks;

namespace GitManager.Methods
{
    internal static class IssuesMethods
    {
        public static async Task<string> CreateIssue(string title, string description)
        {
            return await PostMethods.PostIssue(title: title, description: description);
        }
        public static async Task<string> UpdateIssue(Int64 issueId, string title, string description)
        {
            return await PatchMethods.PatchIssue(issueId: issueId, title: title, description: description);
        }
    }
}