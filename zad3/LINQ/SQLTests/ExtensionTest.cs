using LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLTests
{
    [TestClass]
    public class ExtensionTest
    {
        [TestMethod]
        public void GetProductsWithoutCategoryListDeclarativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                List<Product> results = products.GetProductsWithoutCategoryDeclarative();

                foreach (Product product in results)
                {
                    Assert.IsNull(product.ProductSubcategory);
                }

                Assert.AreEqual(208, results.Count);
            }
        }

        [TestMethod]
        public void GetProductsWithoutCategoryListImperativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                List<Product> results = products.GetProductsWithoutCategoryImperative();

                foreach (Product product in results)
                {
                    Assert.IsNull(product.ProductSubcategory);
                }

                Assert.AreEqual(208, results.Count);
            }
        }

        [TestMethod]
        public void GetProductsPageDeclarativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                List<Product> results = products.GetProductsPagesDeclarative(5, 5);

                Assert.AreEqual(results.Count, 5);

                Assert.AreEqual(products[20].ProductID, results[0].ProductID);
                Assert.AreEqual(products[20].Name, results[0].Name);

                Assert.AreEqual(products[21].ProductID, results[1].ProductID);
                Assert.AreEqual(products[21].Name, results[1].Name);

                Assert.AreEqual(products[22].ProductID, results[2].ProductID);
                Assert.AreEqual(products[22].Name, results[2].Name);

                Assert.AreEqual(products[23].ProductID, results[3].ProductID);
                Assert.AreEqual(products[23].Name, results[3].Name);

                Assert.AreEqual(products[24].ProductID, results[4].ProductID);
                Assert.AreEqual(products[24].Name, results[4].Name);
            }
        }

        [TestMethod]
        public void GetProductsPageImperativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                List<Product> results = products.GetProductsPagesImperative(5, 5);

                Assert.AreEqual(results.Count, 5);

                Assert.AreEqual(products[20].ProductID, results[0].ProductID);
                Assert.AreEqual(products[20].Name, results[0].Name);

                Assert.AreEqual(products[21].ProductID, results[1].ProductID);
                Assert.AreEqual(products[21].Name, results[1].Name);

                Assert.AreEqual(products[22].ProductID, results[2].ProductID);
                Assert.AreEqual(products[22].Name, results[2].Name);

                Assert.AreEqual(products[23].ProductID, results[3].ProductID);
                Assert.AreEqual(products[23].Name, results[3].Name);

                Assert.AreEqual(products[24].ProductID, results[4].ProductID);
                Assert.AreEqual(products[24].Name, results[4].Name);
            }
        }

        [TestMethod]
        public void GetProductVendorPairsDeclarativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                List<ProductVendor> vendors = productionDataContext.GetTable<ProductVendor>().ToList();

                string result = products.GetProductVendorPairsDeclarative(vendors);
                string[] lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                Assert.AreEqual(460, lines.Length);
                Assert.IsTrue(lines.Contains("Thin-Jam Hex Nut 6 - Advanced Bicycles"));
                Assert.IsTrue(lines.Contains("Hex Nut 6 - Cruger Bike Company"));
                Assert.IsTrue(lines.Contains("Flat Washer 8 - Speed Corporation"));
                Assert.IsTrue(lines.Contains("Crown Race - Business Equipment Center"));
                Assert.IsTrue(lines.Contains("Chainring Nut - Training Systems"));
            }
        }

    }
}
