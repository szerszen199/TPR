using System;
using System.Collections.Generic;
using System.Reflection;


namespace Shop.DataTypes
{
    public class Bill : IBill
    {
        public int AmountBought { get; set; }
        public Client Client { get; set; }
        public MagazineState MagazineState { get; set; }
        public Product Product { get; set; }
        public Double Paid { get; set; }

        public Bill(int amountBought, Client client, MagazineState magazineState, Product product)
        {
            AmountBought = amountBought;
            Client = client;
            MagazineState = magazineState;
            Product = product;
            Paid = amountBought * product.Cost;
        }
    }
}

