using System;

namespace Logic
{
    public class ProductReview : IProductReview
    {
        public ProductReview() { }

        public ProductReview(Data.ProductReview productReview)
        {
            this.productReviewID = productReview.ProductReviewID;
            this.productID = productReview.ProductID;
            this.reviewerName = productReview.ReviewerName;
            this.reviewDate = productReview.ReviewDate;
            this.emailAddress = productReview.EmailAddress;
            this.rating = productReview.Rating;
            this.comments = productReview.Comments;
            this.modifiedDate = productReview.ModifiedDate;
        }



        public int productReviewID { get; set; }
        public int productID { get; set; }
        public string reviewerName { get; set; }
        public DateTime reviewDate { get; set; }
        public string emailAddress { get; set; }
        public int rating { get; set; }
        public string comments { get; set; }
        private DateTime modifiedDate { get; set; }
    }
}
