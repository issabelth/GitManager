using GitAPI;
using GitAPI.Methods;
using GitAPI.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    state: issue.State);
            }
            else
            {
                return await CreateIssue(
                    client: client,
                    title: issue.Title,
                    description: issue.Description);
            }
        }

        private static async Task<string> UpdateIssue(GitClient client, int issueNumber, string title, string description, string state)
        {
            switch (HostData.Host)
            {
                case HostData.HostNameEnum.Github:
                    {
                        return await PatchMethods.PatchIssue(client: client, issueNumber: issueNumber, title: title, description: description, state: state);
                    }
                case HostData.HostNameEnum.Gitlab:
                    {
                        var responseContent = await GetMethods.GetProjectByName_GitLab(client: AppClient.Client, projectName: ApiOptions.ProjectName);
                        var projects = JsonConvert.DeserializeObject<List<dynamic>>(responseContent);
                        string projectId = projects.Where(x => x.name == ApiOptions.ProjectName).FirstOrDefault()?.id;

                        return await PutMethods.PutIssue_GitLab(client: client, projectId: projectId, issueNumber: issueNumber, title: title, description: description, state: state);
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private static async Task<string> CreateIssue(GitClient client, string title, string description)
        {
            switch (HostData.Host)
            {
                case HostData.HostNameEnum.Github:
                    {
                        return await PostMethods.PostIssue_GitHub(client: client, title: title, description: description);
                    }
                case HostData.HostNameEnum.Gitlab:
                    {
                        var responseContent = await GetMethods.GetProjectByName_GitLab(client: AppClient.Client, projectName: ApiOptions.ProjectName);
                        var projects = JsonConvert.DeserializeObject<List<dynamic>>(responseContent);
                        string projectId = projects.Where(x => x.name == ApiOptions.ProjectName).FirstOrDefault()?.id;

                        return await PostMethods.PostIssue_GitLab(client: client, title: title, description: description, projectId: projectId);
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public static async Task<string> GetIssue(GitClient client, string issueId)
        {
            switch (HostData.Host)
            {
                case HostData.HostNameEnum.Github:
                    {
                        return await GetMethods.GetIssue_GitHub(client: client, issueId: issueId);
                    }
                case HostData.HostNameEnum.Gitlab:
                    {
                        var responseContent = await GetMethods.GetProjectByName_GitLab(client: AppClient.Client, projectName: ApiOptions.ProjectName);
                        var projects = JsonConvert.DeserializeObject<List<dynamic>>(responseContent);
                        string projectId = projects.Where(x => x.name == ApiOptions.ProjectName).FirstOrDefault()?.id;

                        if (string.IsNullOrWhiteSpace(projectId))
                        {
                            throw new Exception("Could not find your project");
                        }

                        return await GetMethods.GetIssue_GitLab(client: client, issueId: issueId, projectId: projectId);
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public static async Task<string> GetIssues(GitClient client)
        {
            switch (HostData.Host)
            {
                case HostData.HostNameEnum.Github:
                    {
                        return await GetMethods.GetIssues_GiHub(client: client);
                    }
                case HostData.HostNameEnum.Gitlab:
                    {
                        var responseContent = await GetMethods.GetProjectByName_GitLab(client: AppClient.Client, projectName: ApiOptions.ProjectName);
                        var projects = JsonConvert.DeserializeObject<List<dynamic>>(responseContent);
                        string projectId = projects.Where(x => x.name == ApiOptions.ProjectName).FirstOrDefault()?.id;

                        if (string.IsNullOrWhiteSpace(projectId))
                        {
                            throw new Exception("Could not find your project");
                        }

                        return await GetMethods.GetIssues_GitLab(client: client, projectId: projectId, addParameters: "?state=opened");
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

    }
}