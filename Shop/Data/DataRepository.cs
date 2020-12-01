
using Shop.Data.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Shop.Data
{
    internal class DataRepository : IDataRepository
    {
        public DataContext dataContext { get; set; }
        public IDataFiller DataFiller;

        public void SetDataContext(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public DataContext GetDataContext()
        {
            return dataContext;
        }
        public DataRepository(IDataFiller dataFiller)
        {
            dataContext = new DataContext();
            DataFiller = dataFiller;
        }

        public DataRepository()
        {
            dataContext = new DataContext();
        }

        public void AddProduct(Guid guid, double Cost, string ProductName)
        {
            Product product = new Product(guid, Cost, ProductName);
            dataContext.products.Add(guid, product);
        }

        public IProduct GetProduct(Guid guid)
        {
            return dataContext.products[guid];
        }

        public Dictionary<Guid, IProduct> GetAllProducts()
        {
            return dataContext.products;
        }

        public void UpdateProduct(Guid guid, double cost, string productName)
        {
            dataContext.products[guid].Cost = cost;
            dataContext.products[guid].ProductName = productName;
        }

        public void DeleteProduct(Guid guid)
        {
            dataContext.products.Remove(guid);
        }

        public void AddClient(string firstName, string surname)
        {
            IClient client = new Client(firstName, surname);
            dataContext.clients.Add(client);
        }

        public IClient GetClient(int n)
        {
            for (int i = 0; i < dataContext.clients.Count; i++)
            {
                if (n == i)
                {
                    return dataContext.clients[i];
                }
            }
            return null;
        }

        public List<IClient> GetAllClients()
        {
            return dataContext.clients;
        }

        public void SetAllClients(List<IClient> clients)
        {
            dataContext.clients = clients;
        }

        public void UpdateClient(IClient client, string firstName, string surName)
        {
            client.FirstName = firstName;
            client.SurName = surName;

        }

        public void DeleteClient(IClient client)
        {
            for (int i = 0; i < dataContext.clients.Count; i++)
            {
                if (client == dataContext.clients[i])
                {
                    dataContext.clients.RemoveAt(i);
                }
            }
        }

        public void AddMagazineState(IProduct product, int amount)
        {
            IMagazineState magazineState = new MagazineState(product, amount);
            dataContext.magazineStates.Add(magazineState);
        }

        public IMagazineState GetMagazineState(int n)
        {
            for (int i = 0; i < dataContext.magazineStates.Count; i++)
            {
                if (n == i)
                {
                    return dataContext.magazineStates[i];
                }
            }
            return null;
        }
        public ObservableCollection<IMagazineState> GetAllMagazineStates()
        {
            return dataContext.magazineStates;
        }

        public void UpdateMagazineState(IMagazineState magazineState, IProduct product, int amount)
        {
            magazineState.Product = product;
            magazineState.Amount = amount;

        }

        public void DeleteMagazineState(IMagazineState magazineState)
        {
            for (int i = 0; i < dataContext.magazineStates.Count; i++)
            {
                if (magazineState == dataContext.magazineStates[i])
                {
                    dataContext.magazineStates.RemoveAt(i);
                }
            }
        }

        public void AddBill(int amountBought, IClient client, IMagazineState magazineState, IProduct product)
        {
            StockEvent bill = new Bill(amountBought, client, magazineState, product);
            dataContext.stockEvents.Add(bill);
        }

        public StockEvent GetEvent(int n)
        {
            for (int i = 0; i < dataContext.stockEvents.Count; i++)
            {
                if (n == i)
                {
                    return dataContext.stockEvents[i];
                }
            }
            return null;
        }
        public ObservableCollection<StockEvent> GetAllStockEvents()
        {
            return dataContext.stockEvents;
        }
        public void UpdateBill(IBill bill, int amount, IClient client, IMagazineState magazineState, IProduct product)
        {
            bill.Amount = amount;
            bill.Client = client;
            bill.MagazineState = magazineState;
            bill.Product = product;
        }

        public void DeleteBill(IBill bill)
        {
            for (int i = 0; i < dataContext.stockEvents.Count; i++)
            {
                if (bill == dataContext.stockEvents[i])
                {
                    dataContext.stockEvents.RemoveAt(i);
                }
            }
        }

        public void AddRestock(int amount, IMagazineState magazineState, IProduct product)
        {
            StockEvent restock = new Restock(amount, magazineState, product);
            dataContext.stockEvents.Add(restock);
        }

        public void UpdateRestock(IRestock restock, int amount, IMagazineState magazineState, IProduct product)
        {
            restock.Amount = amount;
            restock.MagazineState = magazineState;
            restock.Product = product;
        }

        public void DeleteRestock(IRestock restock)
        {
            for (int i = 0; i < dataContext.stockEvents.Count; i++)
            {
                if (restock == dataContext.stockEvents[i])
                {
                    dataContext.stockEvents.RemoveAt(i);
                }
            }
        }

        public void Fill()
        {
            DataFiller.Fill(dataContext);
        }

    }
}