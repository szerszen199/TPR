using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataTypes
{
    public class Restock : StockEvent
    {

        public Restock(int amount, Client client, MagazineState magazineState, Product product) : base(amount, client, magazineState, product)
        {
        }
    }
}
