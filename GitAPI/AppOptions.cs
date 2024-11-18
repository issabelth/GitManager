using System.IO;
using YamlDotNet.Serialization;

namespace GitAPI
{
    public static class AppFile
    {
        public static string AppFilePath { get; set; }
    }

    public class AppOptions
    {
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

        public static AppOptions FromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            AppFile.AppFilePath = filePath;
            var deserializer = new Deserializer();
            AppOptions options;

            using (var reader = File.OpenText(filePath))
            {
                options = deserializer.Deserialize<AppOptions>(reader);
            }

            return options;
        }
    }
}
