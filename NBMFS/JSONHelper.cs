using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace NBMFS
{
    class JSONHelper
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public static string JsonSerializer<T>(T t)
        {
            string jsonString = JsonConvert.SerializeObject(t, settings);
            return jsonString;
        }

        public static T JsonDeserialize<T>(string jsonString)
        {
            T obj = JsonConvert.DeserializeObject<T>(jsonString, settings);
            return obj;
        }
    }
}
