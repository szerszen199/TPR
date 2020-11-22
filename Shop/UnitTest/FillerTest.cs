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
    public class FillerTest
    {

        [TestMethod]
        public void fillRandomTest()
        {
            IDataRepository dataRepository = new DataRepository(new RandomFiller());
            dataRepository.Fill();

            Assert.AreEqual(7,dataRepository.GetAllClients().Count);
            Assert.AreEqual(3, dataRepository.GetAllProducts().Count);
            Assert.AreEqual(3, dataRepository.GetAllMagazineStates().Count);
            Assert.AreEqual(3, dataRepository.GetStockEvents().Count);
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
            Assert.AreEqual(4, dataRepository.GetEvent(0).Amount);

        }
    }
}
