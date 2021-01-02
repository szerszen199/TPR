using System;
using System.IO;

namespace Serialization.Serializer
{
    public class SerializeContoller
    {
        static public Boolean SertializeObject(object myObject, string filename)
        {
            CustomSerializer serializer = new CustomSerializer();
            Stream stream = File.Open(filename, FileMode.Create);
            try
            {
                serializer.Serialize(stream, myObject);
            }
            catch (System.InvalidCastException)
            {
                stream.Close();
                return false;
            }
            stream.Close();
            return true;
        }
        static public object DesertializeObject(string filename)
        {
            CustomSerializer serializer = new CustomSerializer();
            Stream stream = File.Open(filename, FileMode.Open);
            object objCopy = new object();
            try
            {
                objCopy = serializer.Deserialize(stream);
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                stream.Close();
                return objCopy;
            }
            stream.Close();
            return objCopy;
        }


    }
}
