using Shop.Data.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Data.DataTypes
{
    public class Restock : StockEvent ,IRestock
    {

        public Restock(int amount, IMagazineState magazineState, IProduct product) : base(amount, magazineState, product)
        {
        }
    }
}
