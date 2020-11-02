using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop;
using Shop.DataTypes;
using ShopProject.Shop.DataFiller;
using System;


namespace DataTests
{
    [TestClass]
    public class DataRepositoryTest
    {

        public DataRepository dataRepository = new DataRepository();

        [TestMethod]
        public void ProductTest()
        {

            Guid ProductGuid= new Guid("C83CC55E-8C61-444F-86EA-54C5F53B9B3E");
            dataRepository.AddProduct(ProductGuid, 10.98, "table");
            Product testProduct = dataRepository.GetProduct(ProductGuid);
            Assert.AreEqual(10.98, testProduct.Cost);
            Assert.AreEqual("table", testProduct.ProductName);
            dataRepository.UpdateProduct(ProductGuid, 15.99, "Wooden table");
            Assert.AreEqual(15.99, testProduct.Cost);
            Assert.AreEqual("Wooden table", testProduct.ProductName);
            dataRepository.DeleteProduct(ProductGuid);
            // TODO  delete product is not tested not sure how to test it.
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
            Guid ProductGuid = new Guid("C83CC55E-8C61-444F-86EA-54C5F53B9B3E");
            dataRepository.AddProduct(ProductGuid, 10.98, "table");
            Product testProduct = dataRepository.GetProduct(ProductGuid);
            dataRepository.AddMagazineState(testProduct, 10);
            MagazineState testMagazineState = dataRepository.GetMagazineState(0);
            Assert.AreEqual(testProduct, testMagazineState.Product);
            Assert.AreEqual(10, testMagazineState.Amount);
            dataRepository.UpdateMagazineState(testMagazineState, testProduct, 99);
            Assert.AreEqual(testProduct, dataRepository.GetProduct(ProductGuid));
            Assert.AreEqual(99, testMagazineState.Amount);
            dataRepository.DeleteMagazineState(testMagazineState);
            Assert.AreEqual(null, dataRepository.GetMagazineState(0));
        }

        [TestMethod]
        public void BillTest()
        {
            Guid ProductGuid = new Guid();
            dataRepository.AddProduct(ProductGuid, 10.98, "table");
            Product testProduct = dataRepository.GetProduct(ProductGuid);
            dataRepository.AddClient("Tomasz", "Wozniak");
            Client testClient = dataRepository.GetClient(0);
            dataRepository.AddMagazineState(testProduct, 10);
            MagazineState testMagazineState = dataRepository.GetMagazineState(0);
            dataRepository.AddBill(5, testClient, testMagazineState, testProduct);
            Bill testBill = (Bill)dataRepository.GetBill(0);
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
