﻿using System;

namespace Shop.Data.DataTypes
{
    public interface IProduct
    {
        double Cost { get; set; }
        Guid Guid { get; set; }
        string ProductName { get; set; }
    }
}