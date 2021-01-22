using System.Collections.Generic;

namespace Logic
{
    public interface IProductReviewService
    {
        void AddProductReview(IProductReview productReview);
        IEnumerable<IProductReview> GetAllProductReviews();
        IProductReview GetProductReviewByID(int productReviewID);
        void RemoveProductReview(int productReviewID);
        void UpdateProductReview(int productReviewID, IProductReview productReview);
    }
}