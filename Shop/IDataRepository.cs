using Shop.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shop
{
    public interface IDataRepository
    {
        void AddBill(int amountBought, IClient client, IMagazineState magazineState, IProduct product);
        void AddClient(string firstName, string surname);
        void AddMagazineState(IProduct product, int amount);
        void AddProduct(Guid guid, double Cost, string ProductName);
        void AddRestock(int amount, IMagazineState magazineState, IProduct product);
        void DeleteBill(StockEvent bill);
        void DeleteClient(IClient client);
        void DeleteMagazineState(IMagazineState magazineState);
        void DeleteProduct(Guid guid);
        void DeleteRestock(Restock restock);
        void Fill();
        ObservableCollection<StockEvent> GetStockEvents();
        List<IClient> GetAllClients();
        ObservableCollection<IMagazineState> GetAllMagazineStates();
        Dictionary<Guid, IProduct> GetAllProducts();
        IClient GetClient(int n);
        IMagazineState GetMagazineState(int n);
        IProduct GetProduct(Guid guid);
        void UpdateBill(IBill bill, int amount, IClient client, IMagazineState magazineState, IProduct product);
        void UpdateClient(IClient client, string firstName, string surName);
        void UpdateMagazineState(IMagazineState magazineState, IProduct product, int amount);
        void UpdateProduct(Guid guid, double cost, string productName);
        void UpdateRestock(StockEvent restock, int amount, IMagazineState magazineState, IProduct product);
        StockEvent GetEvent(int v);
    }
}