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
        public void fillXMLTest()
        {
            IDataRepository dataRepository = new DataRepository(new FillFromFile());
            FillFromFile fillFromFile = new FillFromFile();
            List<string> firstNames, surNames, guidList, costList, productNameList = new List<string>();


            firstNames = fillFromFile.readElementFromFile("firstName");
            surNames = fillFromFile.readElementFromFile("surName");
            guidList = fillFromFile.readElementFromFile("guid");
            costList = fillFromFile.readElementFromFile("cost");
            productNameList = fillFromFile.readElementFromFile("productName");

            dataRepository.Fill();
            Assert.AreEqual(firstNames[0], dataRepository.GetClient(0).FirstName);
            Assert.AreEqual(surNames[0], dataRepository.GetClient(0).SurName);
            Assert.AreEqual(Guid.Parse(guidList[0]), dataRepository.GetProduct(Guid.Parse(guidList[0])).Guid);
            Assert.AreEqual(double.Parse(costList[0], CultureInfo.InvariantCulture), dataRepository.GetProduct(Guid.Parse(guidList[0])).Cost);
            Assert.AreEqual(productNameList[0], dataRepository.GetProduct(Guid.Parse(guidList[0])).ProductName);

        }

        

        [TestMethod]
        public void fillConstantTest()
        {
            IDataRepository dataRepository = new DataRepository(new ConstantFiller());
            dataRepository.Fill();

            Guid Guid = Guid.Parse("3EA13DB8-DCB3-4ED9-805C-B88AA99AB5C5");

            Assert.AreEqual("Grzegorz", dataRepository.GetClient(0).FirstName);
            Assert.AreEqual("Table", dataRepository.GetProduct(Guid).ProductName);
            Assert.AreEqual(10, dataRepository.GetMagazineState(0).Amount);
            Assert.AreEqual(4, dataRepository.GetBill(0).Amount);

        }
    }
}
