using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data;

namespace Logic
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly ProductReviewDataContext context = new ProductReviewDataContext();

        public void AddProductReview(IProductReview productReview)
        {
            //if (creditCard.ExpMonth <= 0 || creditCard.ExpMonth > 12)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(creditCard.ExpMonth));
            //}

            Data.ProductReview review = CreateDataProductReview(productReview);
            review.ModifiedDate = DateTime.UtcNow;
            context.AddProductReview(review);
        }

        public IProductReview GetProductReviewByID(int productReviewID)
        {
            return new ProductReview(context.GetProductReviewByID(productReviewID));
        }


        public IEnumerable<IProductReview> GetAllProductReviews()
        {
            return context.GetAllProductReviews().Select(review => new ProductReview(review));
        }


        public void UpdateProductReview(int productReviewID, IProductReview productReview)
        {
            Data.ProductReview review = CreateDataProductReview(productReview);
            review.ModifiedDate = DateTime.UtcNow;
            context.UpdateProductReview(productReviewID, review);
        }

        public void RemoveProductReview(int productReviewID)
        {
            context.RemoveProductReview(productReviewID);
        }

        public static Data.ProductReview CreateDataProductReview(IProductReview productReview)
        {
            return new Data.ProductReview
            {
                ProductReviewID = productReview.productReviewID,
                ProductID = productReview.productID,
                ReviewerName = productReview.reviewerName,
                ReviewDate = productReview.reviewDate,
                EmailAddress = productReview.emailAddress,
                Rating = productReview.rating,
                Comments = productReview.comments
            };
        }



    }
}
