using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class MyProductSQLTools
    {
        private List<MyProduct> Products;

        public MyProductSQLTools(List<MyProduct> products)
        {
            Products = products;
        }

        public List<MyProduct> GetMyProductsByName(string namePart)
        {
            List<MyProduct> products = new List<MyProduct>(from product in Products
                                                          where product.Name.Contains(namePart)
                                                           select product);
            return products;
        }

        public List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            List<MyProduct> products = new List<MyProduct>(from product in Products
                                                       where product.ProductReview.Count.Equals(howManyReviews)
                                                       select product);
            return products;
        }

        public List<MyProduct> GetNMyProductsFromCategory(string categoryName, int n)
        {
            List<MyProduct> products = new List<MyProduct>((from product in Products
                                                        where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                                        orderby product.Name ascending
                                                        select product).Take(n));
            return products;
        }


    }
}
