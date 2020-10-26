using Shop;
using Shop.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ShopProject.Shop
{
    class DataService
    {
        private DataRepository dataRepository;
        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void reValueCost(Guid guid, double reValue)
        {
            
        }
        public void reStockt(Product product, int restockValue)
        {

        }


    }
}
