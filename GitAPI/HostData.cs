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
            //Bitbucket,
        }

        public static Dictionary<HostNameEnum, string> HostNameDictionary = new Dictionary<HostNameEnum, string>()
        {
            { HostNameEnum.Github, "github"},
            { HostNameEnum.Gitlab, "gitlab"},
            //{ HostNameEnum.Bitbucket, "bitbucket"},
        };

        public static string GetAllHostsString()
        {
            return string.Join(" / ", HostNameDictionary.Keys);
        }

        public static HostNameEnum? GetHostKey(string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
            {
                throw new ArgumentException("Argument 'hostName' has not been provided");
            }

            hostName = hostName.ToLower();

            if (!HostNameDictionary.Any(x => x.Value == hostName))
            {
                return null;
            }

            var hostKey = HostData.HostNameDictionary.FirstOrDefault(x => x.Value == hostName).Key;

            return hostKey;
        }

    }
}