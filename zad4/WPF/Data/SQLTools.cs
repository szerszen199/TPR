using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public partial class ProductReviewDataContext
    {
        public void AddProductReview(ProductReview productReview)
        {
            this.ProductReview.InsertOnSubmit(productReview);
            this.SubmitChanges();
        }

        public ProductReview GetProductReviewByID(int productReviewID)
        {
            ProductReview productReview = ProductReview.First(review => review.ProductReviewID.Equals(productReviewID));

            return productReview;
        }

        public void UpdateProductReview(int productReviewID, ProductReview productReview)
        {
            ProductReview review = this.GetProductReviewByID(productReviewID);

            foreach (var property in review.GetType().GetProperties())
            {
                property.SetValue(review, property.GetValue(productReview));
            }

            review.ProductReviewID = productReviewID;
            this.SubmitChanges();
        }

        public void RemoveProductReview(int productReviewID)
        {
            ProductReview review = this.GetProductReviewByID(productReviewID);
            this.ProductReview.DeleteOnSubmit(review);

            this.SubmitChanges();
        }

        public IEnumerable<ProductReview> GetAllProductReviews()
        {
            return ProductReview;
        }



    }
}
