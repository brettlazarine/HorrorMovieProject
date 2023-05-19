using Newtonsoft.Json.Linq;

namespace HMOTD
{
    public class GetKey
    {
        // Get API key from appsettings
        public static string GetTMDbKey()
        {
            var key = File.ReadAllText("appsettings.json");
            var TMDbKey = JObject.Parse(key).GetValue("TMDbKey").ToString();
            return TMDbKey;
        }
    }
}
