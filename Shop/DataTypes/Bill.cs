using System;
using System.Collections.Generic;
using System.Reflection;


namespace Shop.DataTypes
{
    public class Bill
    {
        public int amountBought { get; set; }
        public Client client { get; set; }
        public MagazineState magazineState { get; set; }
        public Product product { get; set; }

        public Bill()
        {
        }

        public static implicit operator Bill(List<Bill> v)
        {
            throw new NotImplementedException();
        }
    }
}

