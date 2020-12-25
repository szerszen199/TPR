using Shop.Data.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Data.DataTypes
{
    public interface IRestock
    {
        int Amount { get; set; }
        IMagazineState MagazineState { get; set; }
        IProduct Product { get; set; }
        double Price { get; set; }
    }
}
