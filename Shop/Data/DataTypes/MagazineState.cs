using System;
using System.Collections.Generic;
using System.Reflection;

namespace Shop.Data.DataTypes
{
    public class MagazineState : IMagazineState
    {
        public Guid Guid { get; private set; }
        public IProduct Product { get; set; }
        public int Amount { get; set; }

        public MagazineState(IProduct product, int amount)
        {
            Product = product;
            Amount = amount;
            Guid = product.Guid;
        }
    }
}
