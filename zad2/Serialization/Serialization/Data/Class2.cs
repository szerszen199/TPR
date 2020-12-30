using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Serialization.Data
{
    [Serializable]
    [JsonObject]
    public class Class2 : ISerializable
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public double DoubleVal { get; set; }
        public Class1 Class1 { get; set; }
        public Class3 Class3 { get; set; }
        public Class2(string text, DateTime dateTime, double doubleVal, Class1 class1, Class3 class3)
        {
            Text = text;
            DateTime = dateTime;
            DoubleVal = doubleVal;
            Class1 = class1;
            Class3 = class3;

        }
        public Class2(string text, DateTime dateTime, double doubleVal)
        {
            Text = text;
            DateTime = dateTime;
            DoubleVal = doubleVal;
        }
        public Class2()
        {

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Text", Text);
            info.AddValue("DateTime", DateTime);
            info.AddValue("DoubleVal", DoubleVal);
            info.AddValue("Class1", Class1);
            info.AddValue("Class3", Class3);
        }
    }
}
