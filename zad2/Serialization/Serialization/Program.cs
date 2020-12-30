using Serialization.Data;
using Serialization.Serializer;
using System;
using System.IO;

namespace Serialization
{
    class Program
    {
        private static readonly string filePath = "./data.txt";
        private static readonly string filePathjson = "./data.json";

        static void Main()
        {
            Console.WriteLine("Hello World!");            
            //
            Class1 class1 = new Class1("clasa1", DateTime.Now, 1.111);
            Class2 class2 = new Class2("clasa2", DateTime.Now, 2.222);
            Class3 class3 = new Class3("clasa3", DateTime.Now, 3.333, class1, class2);
            class1.Class2 = class2;
            class1.Class3 = class3;
            class2.Class1 = class1;
            class2.Class3 = class3;
            //

            SerializeContoller.CreateFile(class1, filePath);
            Class1 serializedClass;
            serializedClass = (Class1)SerializeContoller.ReadFile(filePath);
            Console.WriteLine(serializedClass.Text);
            Console.WriteLine(serializedClass.DoubleVal);
            Console.WriteLine(serializedClass.DateTime);
            Console.WriteLine(serializedClass.Class2.Text);
            Console.WriteLine(serializedClass.Class3.Text);

            Console.ReadLine();

            using (FileStream fileStream = new FileStream(filePathjson, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, class1);
                Console.WriteLine("Object serialized");
                Console.WriteLine("Path: " + Directory.GetCurrentDirectory());
            }
            serializedClass = new Class1();
            using (FileStream fileStream = new FileStream(filePathjson, FileMode.Open))
            {
                serializedClass = JsonSerializer.Deserialize<Class1>(fileStream);
                Console.WriteLine(serializedClass.Text);
                Console.WriteLine(serializedClass.DoubleVal);
                Console.WriteLine(serializedClass.DateTime);
                Console.WriteLine(serializedClass.Class2.Text);
                Console.WriteLine(serializedClass.Class3.Text);
            }
            Console.ReadLine();
        }
    }
}
