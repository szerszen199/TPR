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
            Class1 class1 = new Class1("clasa1", DateTime.Now, 1.111);
            Class2 class2 = new Class2("clasa2", DateTime.Now, 2.222);
            Class3 class3 = new Class3("clasa3", DateTime.Now, 3.333, class1, class2);
            class1.Class2 = class2;
            class1.Class3 = class3;
            class2.Class1 = class1;
            class2.Class3 = class3;
            Class1 class11;

            bool exit = false;

            Console.WriteLine("customSerialize (0)");
            Console.WriteLine("customDeserialize(1)");
            Console.WriteLine("JsonSerialize (2)");
            Console.WriteLine("JsonDeserialize(3)");
            Console.WriteLine("Exit (4)");
            while (!exit)
            {
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "0":
                        Console.WriteLine("customSerialize (0)");
                        SerializeContoller.SertializeObject(class1, filePath);
                        break;
                    case "1":
                        Console.WriteLine("customDeserialize(1)");
                        class11 = (Class1)SerializeContoller.DesertializeObject(filePath);
                        Console.WriteLine(class11.Text);
                        Console.WriteLine(class11.DoubleVal);
                        Console.WriteLine(class11.DateTime);
                        Console.WriteLine(class11.Class2.Text);
                        Console.WriteLine(class11.Class3.Text);
                        break;
                    case "2":
                        Console.WriteLine("JsonSerialize (2)");
                        using (FileStream fileStream = new FileStream(filePathjson, FileMode.Create))
                        {
                            JsonSerializer.Serialize(fileStream, class1);
                        }
                        break;
                    case "3":
                        Console.WriteLine("JsonDeserialize(3)");
                        using (FileStream fileStream = new FileStream(filePathjson, FileMode.Open))
                        {
                            class11 = JsonSerializer.Deserialize<Class1>(fileStream);
                        }
                        Console.WriteLine(class11.Text);
                        Console.WriteLine(class11.DoubleVal);
                        Console.WriteLine(class11.DateTime);
                        Console.WriteLine(class11.Class2.Text);
                        Console.WriteLine(class11.Class3.Text);
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Exit (4)");
                        exit = true;
                        break;
                }
            }
        }
    }
}
