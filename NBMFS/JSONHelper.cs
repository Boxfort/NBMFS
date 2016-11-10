﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Reflection;

namespace NBMFS
{
    class JSONHelper
    {
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public static string[] JsonDeserializeToArray(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(string[]);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            string[] obj = (string[]) ser.ReadObject(ms);
            Console.WriteLine(obj);
            return obj;
        }

    }
}
