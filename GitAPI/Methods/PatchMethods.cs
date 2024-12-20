﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitAPI.Methods
{
    public static class PatchMethods
    {

        public static async Task<string> PatchIssue(GitClient client, int issueNumber, string title, string description, string state)
        {
            var json = JsonConvert.SerializeObject(new
            {
                title = title,
                body = description,
                state = state,
            });

            return await client.SendRequest(methodType: new HttpMethod("PATCH"), apiPath: $"{client.BaseIssuesAddress}/{issueNumber}", json: json);
        }


    }
}
