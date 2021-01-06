using System;
using Newtonsoft.Json;

namespace TestApp.Helpers
{
    public static class Utilities
    {
        public static string SerializeToJson(object Object)
        {
            try
            {
                var json = JsonConvert.SerializeObject(Object);
                return json;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public static T DeserializeFromJson<T>(string jsonString)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<T>(jsonString);
                return result;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        
    }
}
