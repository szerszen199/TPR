using Logic;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class ProductReviewOperations
    {
        private readonly IProductReviewService productReviewService;

        public ProductReviewOperations()
        {
            this.productReviewService = new Logic.ProductReviewService();
        }

        public ProductReviewOperations(IProductReviewService productReviewService)
        {
            this.productReviewService = productReviewService;
        }

        public void AddProductReview(ProductReviewModel productReview)
        {
            productReviewService.AddProductReview(productReview);
        }

        public ProductReviewModel GetProductReview(int productReviewId)
        {
            return productReviewService.GetProductReviewByID(productReviewId) as ProductReviewModel;
        }

        public IEnumerable<ProductReviewModel> GetAllProductReviews()
        {
            return productReviewService.GetAllProductReviews().Select(review => new ProductReviewModel(review));
        }

        public void RemoveProductReview(int productReviewId)
        {
            productReviewService.RemoveProductReview(productReviewId);
        }

        public void UpdateProductReview(int productReviewId, ProductReviewModel productReview)
        {
            productReviewService.UpdateProductReview(productReviewId, productReview);
        }

    }
}
