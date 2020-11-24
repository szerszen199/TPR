using System;
using System.Globalization;

namespace Shop.Data.DataTypes
{
    public class Product : IProduct
    {
        public Guid Guid { get; set; }
        public double Cost { get; set; }
        public string ProductName { get; set; }
        public Product(Guid guid, double cost, string productName)
        {
            Guid = guid;
            Cost = cost;
            ProductName = productName;
        }
    }
}
