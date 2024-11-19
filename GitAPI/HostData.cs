using System;
using System.Collections.Generic;
using System.Linq;

namespace GitAPI
{
    public class HostData
    {

        public static HostNameEnum Host;

        public enum HostNameEnum
        {
            Github,
            Gitlab,
            Bitbucket,
        }

        public static Dictionary<HostNameEnum, string> HostNameDictionary = new Dictionary<HostNameEnum, string>()
        {
            { HostNameEnum.Github, "github"},
            { HostNameEnum.Gitlab, "gitlab"},
            { HostNameEnum.Bitbucket, "gitbucket"},
        };

        public static Dictionary<HostNameEnum, string> HostCloseStateNameDictionary = new Dictionary<HostNameEnum, string>()
        {
            { HostNameEnum.Github, "close"},
            { HostNameEnum.Gitlab, "close"},
        };

        public static string HostName()
        {
            var stateName = HostNameDictionary.Where(x => x.Key == Host).FirstOrDefault().Value;

            if (string.IsNullOrWhiteSpace(stateName))
            {
                throw new NotImplementedException($"Close state name for {Host} is not implemented.");
            }

            return stateName;
        }

        public static string GetHostCloseName()
        {
            var stateName = HostCloseStateNameDictionary.Where(x => x.Key == Host).FirstOrDefault().Value;

            if (string.IsNullOrWhiteSpace(stateName))
            {
                throw new NotImplementedException($"Close state name for {Host} is not implemented.");
            }

            return stateName;
        }

    }
}