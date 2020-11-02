using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopProject.Shop.DataFiller;

namespace UnitTests
{
    [TestClass]
    public class FillFromFileTest
    {
        [TestMethod]
        public void fillFromFile()
        {
            FillFromFile fillFromFile = new FillFromFile();

            List<string> lista = new List<string>();

            lista = fillFromFile.readClientFromFile("firstName");

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{lista[i]}");
            }
        }
    }
}
