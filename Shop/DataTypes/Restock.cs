using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataTypes
{
    public class Restock : StockEvent
    {

        public Restock(int amount, MagazineState magazineState, Product product) : base(amount, magazineState, product)
        {
        }
    }
}
