using System;

namespace Shop.DataTypes
{
    public interface IMagazineState
    {
        int Amount { get; set; }
        Guid Guid { get; }
        IProduct Product { get; set; }
    }
}