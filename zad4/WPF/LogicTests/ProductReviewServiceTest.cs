using System.Linq;
using LogicTests.DataModel;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicTests
{
    [TestClass]
    public class ProductReviewServiceTest
    {
        private ProductReview productReview;
        private IProductReviewService productReviewService;

        [TestInitialize]
        public void TestInitialize()
        {
            productReview = new ProductReview
            {
                productReviewID = 3,
                productID = 500,
                reviewerName = "Kate",
                reviewDate = new DateTime(2020, 1, 18),
                emailAddress = "test@test.com",
                rating = 3,
                comments = "Test Comment number 3"
            };
            productReviewService = new TestDataModel();
        }

        [TestMethod]
        public void AddProductReviewTest()
        {
            Assert.AreEqual(2, productReviewService.GetAllProductReviews().Count());
            productReviewService.AddProductReview(productReview);
            Assert.AreEqual(3, productReviewService.GetAllProductReviews().Count());
        }

        [TestMethod]
        public void GetProductReviewTest()
        {
            productReviewService.AddProductReview(productReview);
            Assert.AreEqual(productReview.productReviewID, productReviewService.GetProductReviewByID(productReview.productReviewID).productReviewID);
        }

        [TestMethod]
        public void GetProductReviewsTest()
        {
            Assert.AreEqual(2, productReviewService.GetAllProductReviews().Count());
        }

        [TestMethod]
        public void UpdateProductReviewTest()
        {
            Assert.AreEqual(2, productReviewService.GetAllProductReviews().Count());
            productReviewService.UpdateProductReview(productReviewService.GetAllProductReviews().Last().productReviewID, productReview);
            Assert.AreEqual(2, productReviewService.GetAllProductReviews().Count());
            Assert.AreEqual(productReview.productReviewID, productReviewService.GetAllProductReviews().Last().productReviewID);
        }

        [TestMethod]
        public void DeleteProductReviewTest()
        {
            Assert.AreEqual(2, productReviewService.GetAllProductReviews().Count());
            productReviewService.AddProductReview(productReview);
            Assert.AreEqual(3, productReviewService.GetAllProductReviews().Count());
            productReviewService.RemoveProductReview(productReviewService.GetAllProductReviews().Last().productReviewID);
            Assert.AreEqual(2, productReviewService.GetAllProductReviews().Count());
        }
    }
}
