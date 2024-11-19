using GitAPI;
using GitAPI.Methods;
using GitAPI.Schemas;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GitManager.Methods
{
    internal static class IssuesMethods
    {

        public static async Task<string> SaveIssue(GitClient client, BaseIssue issue)
        {
            if (issue.Number.HasValue)
            {
                return await UpdateIssue(
                    client: client,
                    issueNumber: issue.Number.Value,
                    title: issue.Title,
                    description: issue.Description,
                    state: issue.State
                    //projectName: projectName
                    );
            }
            else
            {
                return await CreateIssue(
                    client: client,
                    title: issue.Title,
                    description: issue.Description,
                    projectName: issue.ProjectName);
            }
        }

        private static async Task<string> CreateIssue(GitClient client, string title, string description, string projectName = "")
        {
            if (HostData.Host == HostData.HostNameEnum.Gitlab)
            {
                var responseContent = await GetMethods.GetProjectByName(client: AppClient.Client, projectName: projectName);
                var issue = JsonConvert.DeserializeObject<BaseIssue>(responseContent);
            }

            return await PostMethods.PostIssue(client: client, title: title, description: description);
        }
        private static async Task<string> UpdateIssue(GitClient client, Int64 issueNumber, string title, string description, string state)
        {
            return await PatchMethods.PatchIssue(client: client, issueNumber: issueNumber, title: title, description: description, state: state);
        }

    }
}