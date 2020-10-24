using System;
using System.Collections.Generic;
using System.Reflection;

namespace Shop.DataTypes
{
    public class MagazineState
    {
        public Product product { get; set; }
        public int Amount { get; set; }

        public MagazineState()
        {

        }
    }
}
