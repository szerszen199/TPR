using System;
using System.Collections.Generic;
using System.Reflection;


namespace Shop.DataTypes
{
    public class Bill : StockEvent
    {
        public Client Client { get; set; }

        public Bill(int amount, Client client, MagazineState magazineState, Product product) : base(amount, magazineState, product)
        {
            Client = client;
        }
    }
}

