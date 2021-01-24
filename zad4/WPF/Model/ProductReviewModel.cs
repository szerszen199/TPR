using System;
using Logic;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Model
{
    public class ProductReviewModel : IProductReview
    {
        public ProductReviewModel()
        {

        }

        public ProductReviewModel(IProductReview productReview)
        {
            this.productReviewID = productReview.productReviewID;
            this.productID = productReview.productID;
            this.reviewerName = productReview.reviewerName;
            this.reviewDate = productReview.reviewDate;
            this.emailAddress = productReview.emailAddress;
            this.rating = productReview.rating;
            this.comments = productReview.comments;
        }

        public ProductReviewModel(int productReviewID, int productID, string reviewerName, DateTime reviewDate, string emailAddress, int rating, string comments, DateTime modifiedDate)
        {
            this.productReviewID = productReviewID;
            this.productID = productID;
            this.reviewerName = reviewerName;
            this.reviewDate = reviewDate;
            this.emailAddress = emailAddress;
            this.rating = rating;
            this.comments = comments;
            this.modifiedDate = modifiedDate;
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
