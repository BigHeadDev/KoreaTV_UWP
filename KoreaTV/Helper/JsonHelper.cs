using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace KoreaTV.Helper {
    public static class JsonHelper {
        public static T ReadToObject<T>(string json) where T : class, new() {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json))) {
                return ser.ReadObject(stream) as T;
            }
        }
    }
}
