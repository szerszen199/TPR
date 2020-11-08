using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop;
using Shop.DataFiller;

namespace UnitTests
{
    [TestClass]
    public class FillFromFileTest
    {
        public DataRepository dataRepository = new DataRepository();
        [TestMethod]
        public void fillFromFile()
        {
            
            DataRepository dataRepository = new DataRepository();

            FillFromFile fillFromFile = new FillFromFile();

            List<string> lista = new List<string>();

            lista = fillFromFile.readElementFromFile("firstName");

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{lista[i]}");
            }
        }
    }
}
