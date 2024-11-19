using System.Collections.Generic;

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
    }
}
