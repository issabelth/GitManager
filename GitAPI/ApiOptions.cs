using System.IO;
using System.Runtime.CompilerServices;
using YamlDotNet.Serialization;

namespace GitAPI
{
    public static class AppFile
    {
        public static string AppFilePath { get; set; }
    }

    public class ApiOptions
    {
        public string Host
        {
            get; set;
        }

        public string Token
        {
            get; set;
        }

        public string Owner
        {
            get; set;
        }

        public string Repo
        {
            get; set;
        }

        public static string ProjectName
        {
            get; set;
        }

        public string GetToken()
        {
            return Token;
        }

        public static ApiOptions FromFile(string filePath, bool getToken = false)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            AppFile.AppFilePath = filePath;
            var deserializer = new Deserializer();
            ApiOptions options;

            using (var reader = File.OpenText(filePath))
            {
                options = deserializer.Deserialize<ApiOptions>(reader);
            }

            if (!getToken)
            {
                ApiOptions.ProjectName = options.Repo;
            }

            return options;
        }
    }
}
