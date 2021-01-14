using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public partial class ProductionDataContext
    {
        public List<Product> GetProductsByName(string namePart)
        {
            List<Product> products = new List<Product>(from product in this.Product
                                                       where product.Name.Contains(namePart)
                                                        select product);
            return products;
        }

        public List<Product> GetProductsByVendorName(string vendorName)
        {
            List<Product> products = new List<Product>(from productVendor in this.ProductVendor
                                                        where productVendor.Vendor.Name.Equals(vendorName)
                                                        select productVendor.Product);
            return products;
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            List<string> productNames = new List<string>(from productVendor in this.ProductVendor
                                                            where productVendor.Vendor.Name.Equals(vendorName)
                                                            select productVendor.Product.Name);
            return productNames;
        }

        public string GetProductVendorByProductName(string productName)
        {
            string vendor = (from productVendor in this.ProductVendor
                                where productVendor.Product.Name.Equals(productName)
                                select productVendor.Vendor.Name).First();
            return vendor;
        }

        public List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            List<Product> products = new List<Product>(from product in this.Product
                                                        where product.ProductReview.Count.Equals(howManyReviews)
                                                        select product);
            return products;
        }

        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            List<Product> products = new List<Product>((from productReview in this.ProductReview
                                                        orderby productReview.ReviewDate descending
                                                        group productReview.Product by productReview.ProductID into gr
                                                        select gr.First()).Take(howManyProducts));
            return products;
        }

        public List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            List<Product> products = new List<Product>((from product in this.Product
                                                        where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                                        orderby product.Name ascending
                                                        select product).Take(n));
            return products;
        }

        public int GetTotalStandardCostByCategory(ProductCategory category)
        {
            int totalStandardCost = (int) (from product in this.Product
                                            where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                                            select product.StandardCost).Sum();
            return totalStandardCost;
        }


    }

}
