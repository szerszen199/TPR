using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public partial class ProductionDataContext
    {

        public List<Product> GetProductsWithoutCategoryQS()
        {
            List<Product> productsWithoutCategory = new List<Product>(from product in this.Product
                                                                      where product.ProductSubcategory == null
                                                                      select product);
            return productsWithoutCategory;
        }

        public List<Product> GetProductsWithoutCategoryMS()
        {
            List<Product> productsWithoutCategory = new List<Product>(this.Product.Where(product => product.ProductSubcategory == null));

            return productsWithoutCategory;
        }

        public List<Product> GetProductsPagesQS(int numberOfProductsOnPage, int numberOfPage)
        {
            List<Product> productsPage = new List<Product>(from product in this.Product
                                                           select product).Skip(numberOfProductsOnPage * (numberOfPage - 1)).Take(numberOfProductsOnPage).ToList();
            return productsPage;
        }

        public List<Product> GetProductsPagesMS(int numberOfProducts, int numberOfPage)
        {
            List<Product> productsPage = new List<Product>(this.Product.Skip(numberOfProducts * (numberOfPage - 1)).Take(numberOfProducts));

            return productsPage;
        }

        public string GetProductVendorPairsQS()
        {
            var productsQuery = (from product in this.Product
                                 from vendor in this.ProductVendor
                                 where vendor.ProductID.Equals(product.ProductID)
                                 select new {productName = product.Name, vendorName = vendor.Vendor.Name});

            return string.Join(Environment.NewLine, productsQuery.Select(x => $"{x.productName} - {x.vendorName}").ToArray<string>());
        }
    
    }
}

