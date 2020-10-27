using Shop;
using Shop.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Shop
{
    public class DataService
    {
        private DataRepository dataRepository;
        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void reStockt(int magazineStateEnum, int restockValue)
        {
            dataRepository.UpdateMagazineState(dataRepository.GetMagazineState(magazineStateEnum),
                dataRepository.GetMagazineState(magazineStateEnum).Product, restockValue);
        }
        public void addNewProductToMagazine(Guid guid, double cost, string productName, int amountOnMagazine)
        {
            dataRepository.AddProduct(guid, cost, productName);
            dataRepository.AddMagazineState(dataRepository.GetProduct(guid), amountOnMagazine);
        }
        public void buyProduct(int clientEnum, Guid guid, int amountBougt, int magazineStateEnum)
        {
            dataRepository.AddBill(amountBougt, dataRepository.GetClient(clientEnum),
                dataRepository.GetMagazineState(magazineStateEnum),
                dataRepository.GetProduct(guid));
            dataRepository.UpdateMagazineState(dataRepository.GetMagazineState(magazineStateEnum),
                dataRepository.GetMagazineState(magazineStateEnum).Product,
                dataRepository.GetMagazineState(magazineStateEnum).Amount - amountBougt);
        }
        public void showAllProducts()
        {
            foreach (KeyValuePair<Guid, Product> product in dataRepository.GetAllProducts())
            {
                Console.WriteLine("Guid = {0}, Cost = {1}, ProductName = {2}", product.Value.Guid, product.Value.Cost, product.Value.ProductName);
            }

        }

    }
}
