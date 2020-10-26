using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop;
using Shop.DataTypes;

namespace DataTests
{
    [TestClass]
    public class DataRepositoryTest
    {

        public DataRepository dataRepository = new DataRepository();

        [TestMethod]
        public void ProductTest()
        {
            dataRepository.AddProduct(10.98, "table");
            Product testProduct = dataRepository.GetProduct(0);
            Assert.AreEqual(10.98, testProduct.Cost);
            Assert.AreEqual("table", testProduct.ProductName);
            dataRepository.UpdateProduct(testProduct, 15.99, "Wooden table");
            Assert.AreEqual(15.99, testProduct.Cost);
            Assert.AreEqual("Wooden table", testProduct.ProductName);
            dataRepository.DeleteProduct(testProduct);
            Assert.AreEqual(null, dataRepository.GetProduct(0));
        }

        [TestMethod]
        public void ClientTest()
        {
            dataRepository.AddClient("Tomasz", "Wozniak");
            Client testClient = dataRepository.GetClient(0);
            Assert.AreEqual("Tomasz", testClient.FirstName);
            Assert.AreEqual("Wozniak", testClient.SurName);
            dataRepository.UpdateClient(testClient, "Grzegorz", "Muszynski");
            Assert.AreEqual("Grzegorz", testClient.FirstName);
            Assert.AreEqual("Muszynski", testClient.SurName);
            dataRepository.DeleteClient(testClient);
            Assert.AreEqual(null, dataRepository.GetClient(0));
        }
        [TestMethod]
        public void MagazineStateTest()
        {
            dataRepository.AddProduct(10.98, "table");
            Product testProduct = dataRepository.GetProduct(0);
            dataRepository.AddMagazineState(testProduct, 10);
            MagazineState testMagazineState = dataRepository.GetMagazineState(0);
            Assert.AreEqual(testProduct, testMagazineState.Product);
            Assert.AreEqual(10, testMagazineState.Amount);
            dataRepository.UpdateMagazineState(testMagazineState, testProduct, 99);
            Assert.AreEqual(testProduct, dataRepository.GetProduct(0));
            Assert.AreEqual(99, testMagazineState.Amount);
            dataRepository.DeleteMagazineState(testMagazineState);
            Assert.AreEqual(null, dataRepository.GetMagazineState(0));
        }

        [TestMethod]
        public void BillTest()
        {
            dataRepository.AddProduct(10.98, "table");
            Product testProduct = dataRepository.GetProduct(0);
            dataRepository.AddClient("Tomasz", "Wozniak");
            Client testClient = dataRepository.GetClient(0);
            dataRepository.AddMagazineState(testProduct, 10);
            MagazineState testMagazineState = dataRepository.GetMagazineState(0);
            dataRepository.AddBill(5, testClient, testMagazineState, testProduct);
            Bill testBill = dataRepository.GetBill(0);
            Assert.AreEqual(5, testBill.AmountBought);
            Assert.AreEqual(testClient, testBill.Client);
            Assert.AreEqual(testMagazineState, testBill.MagazineState);
            Assert.AreEqual(testProduct, testBill.Product);
            dataRepository.UpdateBill(testBill, 10, testClient, testMagazineState, testProduct);
            Assert.AreEqual(10, testBill.AmountBought);

            dataRepository.DeleteBill(testBill);
            Assert.AreEqual(null, dataRepository.GetBill(0));
        }
    }
}
