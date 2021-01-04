using LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LINQTests
{
    [TestClass]
    public class SQLToolsTest
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> listOfProducts = SQLTools.GetProductsByName("Grip Tape");

            Assert.AreEqual(3, listOfProducts.Count);

            Assert.AreEqual(358, listOfProducts[0].ProductID);
            Assert.AreEqual("HL Grip Tape", listOfProducts[0].Name);

            Assert.AreEqual(356, listOfProducts[1].ProductID);
            Assert.AreEqual("LL Grip Tape", listOfProducts[1].Name);

            Assert.AreEqual(357, listOfProducts[2].ProductID);
            Assert.AreEqual("ML Grip Tape", listOfProducts[2].Name);
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> listOfProducts = SQLTools.GetProductsByVendorName("Gardner Touring Cycles");

            Assert.AreEqual(2, listOfProducts.Count);

            Assert.AreEqual(356, listOfProducts[0].ProductID, 320);
            Assert.AreEqual("LL Grip Tape", listOfProducts[0].Name);

            Assert.AreEqual(357, listOfProducts[1].ProductID, 321);
            Assert.AreEqual("ML Grip Tape", listOfProducts[1].Name);
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> listOfProducts = SQLTools.GetProductNamesByVendorName("Gardner Touring Cycles");

            Assert.AreEqual(2, listOfProducts.Count);

            Assert.AreEqual("LL Grip Tape", listOfProducts[0]);
            Assert.AreEqual("ML Grip Tape", listOfProducts[1]);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendor = SQLTools.GetProductVendorByProductName("Bearing Ball");

            Assert.AreEqual("Wood Fitness", vendor);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> listOfProducts = SQLTools.GetProductsWithNRecentReviews(1);

            Assert.AreEqual(2, listOfProducts.Count);

            Assert.AreEqual(709, listOfProducts[0].ProductID);
            Assert.AreEqual("Mountain Bike Socks, M", listOfProducts[0].Name);

            Assert.AreEqual(798, listOfProducts[1].ProductID);
            Assert.AreEqual("Road-550-W Yellow, 40", listOfProducts[1].Name);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> listOfProducts = SQLTools.GetNRecentlyReviewedProducts(3);

            Assert.AreEqual(3, listOfProducts.Count);

            Assert.AreEqual(937, listOfProducts[0].ProductID);
            Assert.AreEqual("HL Mountain Pedal", listOfProducts[0].Name);

            Assert.AreEqual(798, listOfProducts[1].ProductID);
            Assert.AreEqual("Road-550-W Yellow, 40", listOfProducts[1].Name);

            Assert.AreEqual(709, listOfProducts[2].ProductID);
            Assert.AreEqual("Mountain Bike Socks, M", listOfProducts[2].Name);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> listOfProducts = SQLTools.GetNProductsFromCategory("Components", 3);

            Assert.AreEqual(3, listOfProducts.Count);

            Assert.AreEqual(952, listOfProducts[0].ProductID);
            Assert.AreEqual("Chain", listOfProducts[0].Name);

            Assert.AreEqual(948, listOfProducts[1].ProductID);
            Assert.AreEqual("Front Brakes", listOfProducts[1].Name);

            Assert.AreEqual(945, listOfProducts[2].ProductID);
            Assert.AreEqual("Front Derailleur", listOfProducts[2].Name);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Name = "Components";

            int totalStandardCost = SQLTools.GetTotalStandardCostByCategory(productCategory);

            Assert.AreEqual(35930, totalStandardCost);
        }

       
    }
}
