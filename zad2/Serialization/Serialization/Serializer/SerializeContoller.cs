using System;
using System.IO;

namespace Serialization.Serializer
{
    public class SerializeContoller
    {
        static public void SertializeObject(object myObject, string filename)
        {
            CustomSerializer serializer = new CustomSerializer();
            Stream stream = File.Open(filename, FileMode.Create);
            serializer.Serialize(stream, myObject);
            stream.Close();
        }
        static public object DesertializeObject(string filename)
        {
            CustomSerializer serializer = new CustomSerializer();
            Stream stream = File.Open(filename, FileMode.Open);
            object objCopy = new object();
            objCopy = serializer.Deserialize(stream);
            stream.Close();
            return objCopy;
        }


    }
}
