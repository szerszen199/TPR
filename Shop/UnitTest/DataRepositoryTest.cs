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
        public void TestProduct()
        {
            dataRepository.AddProduct(10.98, "table");
            Product testProduct = dataRepository.GetProduct(0);
            Assert.AreEqual(10.98, testProduct.Cost);
            Assert.AreEqual("table", testProduct.ProductName);
            dataRepository.UpdateProduct(dataRepository.GetProduct(0), 15.99, "Wooden table");
            Assert.AreNotEqual(15.00, testProduct.Cost);
            Assert.AreEqual("Wooden table", testProduct.ProductName);
            dataRepository.DeleteProduct(testProduct);
            Assert.AreEqual(null, dataRepository.GetProduct(0));
        }
    }
}
