using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop;
using Shop.DataFiller;

namespace UnitTests
{
    [TestClass]
    public class FillFromFileTest
    {
        public IDataRepository dataRepository = new DataRepository(new FillFromFile());

        [TestMethod]
        public void fillFromFile()
        {
            
            

            FillFromFile fillFromFile = new FillFromFile();

            List<string> lista = new List<string>();

            lista = fillFromFile.readElementFromFile("firstName");

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{lista[i]}");
            }
        }

        [TestMethod]
        public void fillTest()
        {

            FillFromFile fillFromFile = new FillFromFile();
            List<string> firstNames, surNames, guidList, costList, productNameList = new List<string>();


            firstNames = fillFromFile.readElementFromFile("firstName");
            surNames = fillFromFile.readElementFromFile("surName");
            guidList = fillFromFile.readElementFromFile("guid");
            costList = fillFromFile.readElementFromFile("cost");
            productNameList = fillFromFile.readElementFromFile("productName");

            dataRepository.FillClients();
            dataRepository.FillProducts();
            Assert.AreEqual(firstNames[0], dataRepository.GetClient(0).FirstName);
            Assert.AreEqual(surNames[0], dataRepository.GetClient(0).SurName);
            Assert.AreEqual(Guid.Parse(guidList[0]), dataRepository.GetProduct(Guid.Parse(guidList[0])).Guid);
            Assert.AreEqual(double.Parse(costList[0], CultureInfo.InvariantCulture), dataRepository.GetProduct(Guid.Parse(guidList[0])).Cost);
            Assert.AreEqual(productNameList[0], dataRepository.GetProduct(Guid.Parse(guidList[0])).ProductName);

        }
    }
}
