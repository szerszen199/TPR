﻿using System;
using System.Globalization;

namespace Shop.DataTypes
{
    public class Product
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