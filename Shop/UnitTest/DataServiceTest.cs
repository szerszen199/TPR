using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop;
using Shop.DataTypes;
using Shop.DataFiller;
using System;

namespace DataTests
{
    [TestClass]
    public class DataServiceTest
    {

        [TestMethod]
        public void MagazineService()
        {
            DataService dataService = new DataService();
            Guid ProductGuid1 = new Guid("22B08781-191D-4C7F-ABDA-08926898412A");
            Guid ProductGuid2 = new Guid("5B2594A4-9B72-44A2-8B1A-3339AD4F8E97");
            dataService.addNewProductToMagazine(ProductGuid1, 10.99, "pot", 20);
            dataService.addNewProductToMagazine(ProductGuid2, 123, "huge pot", 4);
            dataService.addNewClient("Grzegorz", "Muszynski");
            dataService.buyProduct(0, ProductGuid1, 10, 0);
            dataService.restockProduct(1, ProductGuid2, 10);
            Assert.AreEqual(10, dataService.getMagazineStates()[0].Amount);
            Assert.AreEqual(14, dataService.getMagazineStates()[1].Amount);
            Assert.AreEqual(1, dataService.getClients().Count);
            Assert.AreEqual(2, dataService.getProducts().Count);
            Assert.AreEqual(2, dataService.getMagazineStates().Count);


        }
    }
}
