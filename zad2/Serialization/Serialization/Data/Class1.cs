using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Serialization.Data
{
    [Serializable]
    [JsonObject]
    public class Class1 : ISerializable
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public double DoubleVal { get; set; }
        public Class2 Class2 { get; set; }
        public Class3 Class3 { get; set; }

        public Class1(string text, DateTime dateTime, double doubleVal, Class2 class2, Class3 class3)
        {
            Text = text;
            DateTime = dateTime;
            DoubleVal = doubleVal;
            Class2 = class2;
            Class3 = class3;

        }
        public Class1(string text, DateTime dateTime, double doubleVal)
        {
            Text = text;
            DateTime = dateTime;
            DoubleVal = doubleVal;
        }
        public Class1()
        {

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Text", Text);
            info.AddValue("DateTime", DateTime);
            info.AddValue("DoubleVal", DoubleVal);
            info.AddValue("Class2", Class2);
            info.AddValue("Class3", Class3);
        }
    }
}
