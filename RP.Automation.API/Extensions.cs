using Newtonsoft.Json;

namespace RP.Automation.API
{
    public static class Extensions
    {
        public static T Deserialize<T>(this string value) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
