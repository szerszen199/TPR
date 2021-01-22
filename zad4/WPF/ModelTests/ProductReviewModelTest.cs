using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;

namespace ModelTests
{
    [TestClass]
    public class ProductReviewModelTest
    {
        private ProductReviewModel review;

        [TestInitialize]
        public void TestInitialize()
        {
            review = new ProductReviewModel
            {
                productReviewID = 3,
                productID = 500,
                reviewerName = "Kate",
                reviewDate = new DateTime(2020, 1, 18),
                emailAddress = "test@test.com",
                rating = 3,
                comments = "Test Comment number 3"
            };
        }

        [TestMethod]
        public void CreditCardModelCorrect()
        {
            Assert.IsNotNull(review);
            Assert.AreEqual(3, review.productReviewID);
            Assert.AreEqual(500, review.productID);
            Assert.AreEqual("Kate", review.reviewerName);
            Assert.AreEqual(new DateTime(2020, 1, 18), review.reviewDate);
            Assert.AreEqual("test@test.com", review.emailAddress);
            Assert.AreEqual(3, review.rating);
            Assert.AreEqual("Test Comment number 3", review.comments);
        }
    }
}
