using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class Extension
    {

        public static List<Product> GetProductsWithoutCategoryDeclarative(this List<Product> products)
        {
            List<Product> productsWithoutCategory = new List<Product>(from product in products
                                                                      where product.ProductSubcategory == null
                                                                      select product);
            return productsWithoutCategory;
        }

        public static List<Product> GetProductsWithoutCategoryImperative(this List<Product> products)
        {
            List<Product> productsWithoutCategory = new List<Product>(products.Where(product => product.ProductSubcategory == null));

            return productsWithoutCategory;
        }

        public static List<Product> GetProductsPagesDeclarative(this List<Product> products, int numberOfProductsOnPage, int numberOfPage)
        {
            List<Product> productsPage = new List<Product>(from product in products
                                                           select product).Skip(numberOfProductsOnPage * (numberOfPage - 1)).Take(numberOfProductsOnPage).ToList();
            return productsPage;
        }

        public static List<Product> GetProductsPagesImperative(this List<Product> products, int numberOfProducts, int numberOfPage)
        {
            List<Product> productsPage = new List<Product>(products.Skip(numberOfProducts * (numberOfPage - 1)).Take(numberOfProducts));

            return productsPage;
        }

        public static string GetProductVendorPairsDeclarative(this List<Product> products, List<ProductVendor> vendors)
        {
            var productsQuery = (from product in products
                                 from vendor in vendors
                                 where vendor.ProductID.Equals(product.ProductID)
                                 select new {productName = product.Name, vendorName = vendor.Vendor.Name});

            return string.Join(Environment.NewLine, productsQuery.Select(x => $"{x.productName} - {x.vendorName}").ToArray<string>());
        }
    
    }
}

