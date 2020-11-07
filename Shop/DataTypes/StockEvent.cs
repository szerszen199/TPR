﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataTypes
{
    public abstract class StockEvent
    {
        public int Amount { get; set; }
        public Client Client { get; set; }
        public MagazineState MagazineState { get; set; }
        public Product Product { get; set; }
        public Double Price { get; set; }

        public StockEvent(int amount, Client client, MagazineState magazineState, Product product)
        {
            Amount = amount;
            Client = client;
            MagazineState = magazineState;
            Product = product;
            Price = amount * product.Cost;
        }
    }
}
