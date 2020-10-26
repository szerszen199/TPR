using System;
using System.Collections.Generic;
using System.Reflection;

namespace Shop.DataTypes
{
    public class MagazineState
    {
        public Guid Guid { get; private set; }
        public Product Product { get; set; }
        public int Amount { get; set; }

        public MagazineState(Product product ,int amount)
        {
            Product = product;
            Amount = amount;
            Guid = product.Guid;
        }
    }
}
