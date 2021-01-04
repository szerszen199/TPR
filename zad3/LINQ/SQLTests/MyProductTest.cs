using LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SQLTests
{
    [TestClass]
    public class MyProductTest
    {
        [TestMethod]
        public void GetMyProductsByNameTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                MyProductSQLTools myProductDataContext = new MyProductSQLTools(products.AsEnumerable().Select(product => new MyProduct(product)).ToList());
                List<MyProduct> listOfProducts = myProductDataContext.GetMyProductsByName("Grip Tape");

                Assert.AreEqual(3, listOfProducts.Count);

                Assert.AreEqual(358, listOfProducts[2].ProductID);
                Assert.AreEqual("HL Grip Tape", listOfProducts[2].Name);

                Assert.AreEqual(356, listOfProducts[0].ProductID);
                Assert.AreEqual("LL Grip Tape", listOfProducts[0].Name);

                Assert.AreEqual(357, listOfProducts[1].ProductID);
                Assert.AreEqual("ML Grip Tape", listOfProducts[1].Name);
            }
        }

        [TestMethod]
        public void GetMyProductsWithNRecentReviews()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                MyProductSQLTools myProductDataContext = new MyProductSQLTools(products.AsEnumerable().Select(product => new MyProduct(product)).ToList());
                List<MyProduct> listOfProducts = myProductDataContext.GetMyProductsWithNRecentReviews(1);

                Assert.AreEqual(2, listOfProducts.Count);

                Assert.AreEqual(709, listOfProducts[0].ProductID);
                Assert.AreEqual("Mountain Bike Socks, M", listOfProducts[0].Name);

                Assert.AreEqual(798, listOfProducts[1].ProductID);
                Assert.AreEqual("Road-550-W Yellow, 40", listOfProducts[1].Name);
            }
        }

        [TestMethod]
        public void GetNMyProductsFromCategory()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                MyProductSQLTools myProductDataContext = new MyProductSQLTools(products.AsEnumerable().Select(product => new MyProduct(product)).ToList());
                List<MyProduct> listOfProducts = myProductDataContext.GetNMyProductsFromCategory("Components", 3);

                Assert.AreEqual(3, listOfProducts.Count);

                Assert.AreEqual(952, listOfProducts[0].ProductID);
                Assert.AreEqual("Chain", listOfProducts[0].Name);

                Assert.AreEqual(948, listOfProducts[1].ProductID);
                Assert.AreEqual("Front Brakes", listOfProducts[1].Name);

                Assert.AreEqual(945, listOfProducts[2].ProductID);
                Assert.AreEqual("Front Derailleur", listOfProducts[2].Name);

            }
        }

    }
}
