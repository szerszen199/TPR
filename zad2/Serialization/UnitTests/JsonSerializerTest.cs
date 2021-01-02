using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization.Data;
using Serialization.Serializer;
using System;
using System.IO;


namespace UnitTests
{
    [TestClass]
    public class JsonSerializerTest
    {
        readonly string filePathjson = "./testData.json";
        readonly static DateTime dateTime = new DateTime(2020,12,28,0,0,0);
        Class1 class1 = new Class1("klasa1", dateTime, 1.111);
        Class2 class2 = new Class2("klasa2", DateTime.Now, 2.222);
        Class3 class3 = new Class3("klasa3", DateTime.Now, 3.333);
        Class1 class11;

        [TestInitialize]
        public void TestInitialize()
        {
            class1.Class2 = class2;
            class1.Class3 = class3;
            class2.Class1 = class1;
            class2.Class3 = class3;
            class3.Class1 = class1;
            class3.Class2 = class2;
        }

        [TestMethod]
        public void TestObjectSerialization()
        {

            using (FileStream fileStream = new FileStream(filePathjson, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, class1);
            }

            using (FileStream fileStream = new FileStream(filePathjson, FileMode.Open))
            {
                class11 = JsonSerializer.Deserialize<Class1>(fileStream);
            }
            Assert.AreEqual(true, !class1.Equals(class11));
        }
        [TestMethod]
        public void TestObjectValuesSerialization()
        {

            using (FileStream fileStream = new FileStream(filePathjson, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, class1);
            }

            using (FileStream fileStream = new FileStream(filePathjson, FileMode.Open))
            {
                class11 = JsonSerializer.Deserialize<Class1>(fileStream);
            }
            Assert.AreEqual(class11.Text, "klasa1");
            Assert.AreEqual(class11.DoubleVal, 1.111);
            Assert.AreEqual(class11.DateTime, dateTime);
            Assert.AreEqual(class11.Class2.Text, class2.Text);
            Assert.AreEqual(class11.Class3.Text, class3.Text);
        }
    }
}
