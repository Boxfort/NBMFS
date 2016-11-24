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

        /// <summary>
        /// Converts an object to a JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>A JSON string</returns>
        public static string JsonSerializer<T>(T t)
        {
            string jsonString = JsonConvert.SerializeObject(t, settings);
            return jsonString;
        }

        /// <summary>
        /// Converts a JSON string back into an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns>Object of type T</returns>
        public static T JsonDeserialize<T>(string jsonString)
        {
            T obj = JsonConvert.DeserializeObject<T>(jsonString, settings);
            return obj;
        }
    }
}
