using GitAPI.Methods;
using System.Threading.Tasks;

namespace GitManager.Methods
{
    internal static class IssuesMethods
    {
        public static async Task<string> CreateIssue(string title, string description)
        {
            return await PostMethods.PostIssue(title: title, description: description);
        }
    }
}