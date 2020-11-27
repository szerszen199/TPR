using System;
using System.Collections.Generic;
using System.Reflection;


namespace Shop.Data.DataTypes
{
    internal class Bill : StockEvent, IBill
    {
        public IClient Client { get; set; }


        public Bill(int amount, IClient client, IMagazineState magazineState, IProduct product) : base(amount, magazineState, product)
        {
            Client = client;
        }
    }
}

