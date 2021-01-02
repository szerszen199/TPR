using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Serialization.Serializer
{
    public class JsonSerializer
    {

        public static void Serialize(Stream serializationStream, object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });
            serializationStream.Write(Encoding.UTF8.GetBytes(json), 0, Encoding.UTF8.GetBytes(json).Length);
        }

        public static T Deserialize<T>(Stream serializationStream)
        {
            byte[] bytes = new byte[serializationStream.Length];
            serializationStream.Read(bytes, 0, bytes.Length);
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes), new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}
