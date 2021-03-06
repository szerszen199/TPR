﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Shop.Data.DataTypes;
using Shop.Data;

namespace Shop.Logic
{
    public class DataService
    {
        private IDataRepository dataRepository;
        public DataService()
        {
            dataRepository = new DataRepository();
        }

        public void restockProduct(int magazineStateEnum, Guid guid, int amount)
        {
            dataRepository.AddRestock(amount, dataRepository.GetMagazineState(magazineStateEnum),
                dataRepository.GetProduct(guid));
            dataRepository.UpdateMagazineState(dataRepository.GetMagazineState(magazineStateEnum),
                dataRepository.GetMagazineState(magazineStateEnum).Product,
                dataRepository.GetMagazineState(magazineStateEnum).Amount + amount);
        }
        public void addNewProductToMagazine(Guid guid, double cost, string productName, int amountOnMagazine)
        {
            dataRepository.AddProduct(guid, cost, productName);
            dataRepository.AddMagazineState(dataRepository.GetProduct(guid), amountOnMagazine);
        }
        public void addNewClient(string firstname, string surName)
        {
            dataRepository.AddClient(firstname, surName);
        }

        public void buyProduct(int clientEnum, Guid guid, int amountBought, int magazineStateEnum)
        {

            dataRepository.AddBill(amountBought, dataRepository.GetClient(clientEnum),
                dataRepository.GetMagazineState(magazineStateEnum),
                dataRepository.GetProduct(guid));
            dataRepository.UpdateMagazineState(dataRepository.GetMagazineState(magazineStateEnum),
                dataRepository.GetMagazineState(magazineStateEnum).Product,
                dataRepository.GetMagazineState(magazineStateEnum).Amount - amountBought);
        }
        public List<IClient> getClients()
        {
            return dataRepository.GetAllClients();
        }

        public Dictionary<Guid, IProduct> getProducts()
        {
            return dataRepository.GetAllProducts();
        }
        public ObservableCollection<IMagazineState> getMagazineStates()
        {
            return dataRepository.GetAllMagazineStates();
        }
    }
}
