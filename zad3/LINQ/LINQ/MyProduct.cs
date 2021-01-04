using System.Data.Linq;

namespace LINQ
{
    public class MyProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public EntitySet<ProductReview> ProductReview { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public ProductSubcategory ProductSubcategory { get; set; }
        public decimal StandardCost { get; set; }

        public MyProduct(Product product)
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.ProductNumber = product.ProductNumber;
            this.ProductReview = product.ProductReview;
            this.ProductSubcategoryID = product.ProductSubcategoryID;
            this.ProductSubcategory = product.ProductSubcategory;
            this.StandardCost = product.StandardCost;
        }

        public MyProduct(int productId, string name, string productNumber, int? productSubcategoryId, ProductSubcategory productSubcategory, EntitySet<ProductVendor> productVendors, decimal standardCost)
        {
            ProductID = productId;
            Name = name;
            ProductNumber = productNumber;
            ProductSubcategoryID = productSubcategoryId;
            ProductSubcategory = productSubcategory;
            StandardCost = standardCost;
        }
    }

}

