using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Serialization.Data
{
    [Serializable]
    [JsonObject]
    public class Class3 : ISerializable
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public double DoubleVal { get; set; }
        public Class1 Class1 { get; set; }
        public Class2 Class2 { get; set; }
        public Class3(string text, DateTime dateTime, double doubleVal, Class1 class1, Class2 class2)
        {
            Text = text;
            DateTime = dateTime;
            DoubleVal = doubleVal;
            Class1 = class1;
            Class2 = class2;

        }
        public Class3(string text, DateTime dateTime, double doubleVal)
        {
            Text = text;
            DateTime = dateTime;
            DoubleVal = doubleVal;
        }
        public Class3()
        {

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Text", Text);
            info.AddValue("DateTime", DateTime);
            info.AddValue("DoubleVal", DoubleVal);
            info.AddValue("Class1", Class1);
            info.AddValue("Class2", Class2);
        }
    }
}