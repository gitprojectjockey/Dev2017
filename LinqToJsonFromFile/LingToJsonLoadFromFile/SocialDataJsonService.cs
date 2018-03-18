using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace LingToJsonLoadFromFile
{
    public class SocialDataJsonService
    {
        private readonly string _fileName = string.Empty;
        
        public SocialDataJsonService()
        {
            _fileName = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\SocialData.json";
            using (StreamReader file = File.OpenText(_fileName))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JArray jsonArray = JArray.Parse(File.ReadAllText(_fileName));
            }
        }
    }
}
