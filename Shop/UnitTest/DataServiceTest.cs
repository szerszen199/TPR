using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop;
using Shop.DataTypes;
using System;

namespace DataTests
{
    [TestClass]
    public class DataServiceTest
    {
        DataRepository dataRepository = new DataRepository();

        [TestMethod]
        public void MagazineService()
        {
            DataService dataService = new DataService(dataRepository);
            Guid ProductGuid1 = new Guid("22B08781-191D-4C7F-ABDA-08926898412A");
            Guid ProductGuid2 = new Guid("5B2594A4-9B72-44A2-8B1A-3339AD4F8E97");
            dataService.addNewProductToMagazine(ProductGuid1, 10.99, "pot", 20);
            dataService.addNewProductToMagazine(ProductGuid2, 123, "huge pot", 4);
            dataService.addNewClient("Grzegorz", "Muszynski");
            dataService.buyProduct(0, ProductGuid1, 10, 0);
            //TODO test buing product by client and show bills;
            dataService.showAllProducts();
            dataService.showAllMagazineStates();
            dataService.showAllBills();
            dataService.showAllClients();
        }
    }
}
