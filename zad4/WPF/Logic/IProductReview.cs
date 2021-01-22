using System;

namespace Logic
{
    public interface IProductReview
    {
        string comments { get; set; }
        string emailAddress { get; set; }
        int productID { get; set; }
        int productReviewID { get; set; }
        int rating { get; set; }
        DateTime reviewDate { get; set; }
        string reviewerName { get; set; }

    }
}