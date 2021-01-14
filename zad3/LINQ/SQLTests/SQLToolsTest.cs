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
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> listOfProducts = productionDataContext.GetProductsByName("Grip Tape");

                Assert.AreEqual(3, listOfProducts.Count);

                Assert.AreEqual(358, listOfProducts[0].ProductID);
                Assert.AreEqual("HL Grip Tape", listOfProducts[0].Name);

                Assert.AreEqual(356, listOfProducts[1].ProductID);
                Assert.AreEqual("LL Grip Tape", listOfProducts[1].Name);

                Assert.AreEqual(357, listOfProducts[2].ProductID);
                Assert.AreEqual("ML Grip Tape", listOfProducts[2].Name);
            }

        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> listOfProducts = productionDataContext.GetProductsByVendorName("Gardner Touring Cycles");

                Assert.AreEqual(2, listOfProducts.Count);

                Assert.AreEqual(356, listOfProducts[0].ProductID, 320);
                Assert.AreEqual("LL Grip Tape", listOfProducts[0].Name);

                Assert.AreEqual(357, listOfProducts[1].ProductID, 321);
                Assert.AreEqual("ML Grip Tape", listOfProducts[1].Name);
            }

        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> listOfProducts = productionDataContext.GetProductNamesByVendorName("Gardner Touring Cycles");

                Assert.AreEqual(2, listOfProducts.Count);

                Assert.AreEqual("LL Grip Tape", listOfProducts[0]);
                Assert.AreEqual("ML Grip Tape", listOfProducts[1]);
            }
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                string vendor = productionDataContext.GetProductVendorByProductName("Bearing Ball");

                Assert.AreEqual("Wood Fitness", vendor);
            }
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> listOfProducts = productionDataContext.GetProductsWithNRecentReviews(1);

                Assert.AreEqual(2, listOfProducts.Count);

                Assert.AreEqual(709, listOfProducts[0].ProductID);
                Assert.AreEqual("Mountain Bike Socks, M", listOfProducts[0].Name);

                Assert.AreEqual(798, listOfProducts[1].ProductID);
                Assert.AreEqual("Road-550-W Yellow, 40", listOfProducts[1].Name);
            }
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> listOfProducts = productionDataContext.GetNRecentlyReviewedProducts(3);

                Assert.AreEqual(3, listOfProducts.Count);

                Assert.AreEqual(937, listOfProducts[0].ProductID);
                Assert.AreEqual("HL Mountain Pedal", listOfProducts[0].Name);

                Assert.AreEqual(798, listOfProducts[1].ProductID);
                Assert.AreEqual("Road-550-W Yellow, 40", listOfProducts[1].Name);

                Assert.AreEqual(709, listOfProducts[2].ProductID);
                Assert.AreEqual("Mountain Bike Socks, M", listOfProducts[2].Name);
            }
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> listOfProducts = productionDataContext.GetNProductsFromCategory("Components", 3);

                Assert.AreEqual(3, listOfProducts.Count);

                Assert.AreEqual(952, listOfProducts[0].ProductID);
                Assert.AreEqual("Chain", listOfProducts[0].Name);

                Assert.AreEqual(948, listOfProducts[1].ProductID);
                Assert.AreEqual("Front Brakes", listOfProducts[1].Name);

                Assert.AreEqual(945, listOfProducts[2].ProductID);
                Assert.AreEqual("Front Derailleur", listOfProducts[2].Name);
            }

        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                ProductCategory productCategory = new ProductCategory();
                productCategory.Name = "Components";

                int totalStandardCost = productionDataContext.GetTotalStandardCostByCategory(productCategory);

                Assert.AreEqual(35930, totalStandardCost);
            }
            
        }

       
    }
}
