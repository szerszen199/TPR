using Shop.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shop
{
    public interface IDataRepository
    {
        void AddBill(int amountBought, Client client, MagazineState magazineState, Product product);
        void AddClient(string firstName, string surname);
        void AddMagazineState(Product product, int amount);
        void AddProduct(Guid guid, double Cost, string ProductName);
        void AddRestock(int amount, MagazineState magazineState, Product product);
        void DeleteBill(Bill bill);
        void DeleteClient(Client client);
        void DeleteMagazineState(MagazineState magazineState);
        void DeleteProduct(Guid guid);
        void DeleteRestock(Restock restock);
        void Fill();
        ObservableCollection<StockEvent> GetStockEvents();
        List<Client> GetAllClients();
        ObservableCollection<MagazineState> GetAllMagazineStates();
        Dictionary<Guid, Product> GetAllProducts();
        Client GetClient(int n);
        MagazineState GetMagazineState(int n);
        Product GetProduct(Guid guid);
        void UpdateBill(Bill bill, int amount, Client client, MagazineState magazineState, Product product);
        void UpdateClient(Client client, string firstName, string surName);
        void UpdateMagazineState(MagazineState magazineState, Product product, int amount);
        void UpdateProduct(Guid guid, double cost, string productName);
        void UpdateRestock(Restock restock, int amount, MagazineState magazineState, Product product);
        StockEvent GetEvent(int v);
    }
}