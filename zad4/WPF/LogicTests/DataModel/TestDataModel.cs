using System;
using System.Collections.Generic;
using System.Linq;
using Logic;

namespace LogicTests.DataModel
{
    public class TestDataModel : IProductReviewService
    {
        private readonly List<IProductReview> _context = new List<IProductReview>();

        public TestDataModel()
        {
            ProductReview review1 = new ProductReview
            {
                productReviewID = 1,
                productID = 500,
                reviewerName = "John",
                reviewDate = new DateTime(2017, 1, 18),
                emailAddress = "test@test.com",
                rating = 3,
                comments = "Test Comment number 1"
        };
            ProductReview review2 = new ProductReview
            {
                productReviewID = 2,
                productID = 500,
                reviewerName = "John",
                reviewDate = new DateTime(2017, 5, 18),
                emailAddress = "test@test.com",
                rating = 5,
                comments = "Test Comment number 2"
            };
            AddProductReview(review1);
            AddProductReview(review2);
        }

        public void AddProductReview(IProductReview productReview)
        {
             _context.Add(productReview);
        }

        public IEnumerable<IProductReview> GetAllProductReviews()
        {
            return _context;
        }

        public IProductReview GetProductReviewByID(int productReviewID)
        {
            return _context.Single(review => review.productReviewID.Equals(productReviewID));
        }

        public void RemoveProductReview(int productReviewID)
        {
            IProductReview review = GetProductReviewByID(productReviewID);
            _context.Remove(review);
        }

        public void UpdateProductReview(int productReviewID, IProductReview productReview)
        {
            IProductReview updatedReview = GetProductReviewByID(productReviewID);
            updatedReview.productReviewID = productReview.productReviewID;
            updatedReview.productID = productReview.productID;
            updatedReview.reviewerName = productReview.reviewerName;
            updatedReview.reviewDate = productReview.reviewDate;
            updatedReview.emailAddress = productReview.emailAddress;
            updatedReview.rating = productReview.rating;
            updatedReview.comments = productReview.comments;

        }
    }
}
