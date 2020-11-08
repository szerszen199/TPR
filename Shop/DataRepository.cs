using System;
using Shop.DataTypes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shop.DataFiller;
using System.Globalization;

namespace Shop
{
    public class DataRepository : IDataRepository
    {
        public DataContext dataContext;
        public IDataFiller DataFiller;

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

        public Product GetProduct(Guid guid)
        {
            return dataContext.products[guid];
        }

        public Dictionary<Guid, Product> GetAllProducts()
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
            Client client = new Client(firstName, surname);
            dataContext.clients.Add(client);
        }

        public Client GetClient(int n)
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

        public List<Client> GetAllClients()
        {
            return dataContext.clients;
        }

        public void UpdateClient(Client client, string firstName, string surName)
        {
            client.FirstName = firstName;
            client.SurName = surName;

        }

        public void DeleteClient(Client client)
        {
            for (int i = 0; i < dataContext.clients.Count; i++)
            {
                if (client == dataContext.clients[i])
                {
                    dataContext.clients.RemoveAt(i);
                }
            }
        }

        public void AddMagazineState(Product product, int amount)
        {
            MagazineState magazineState = new MagazineState(product, amount);
            dataContext.magazineStates.Add(magazineState);
        }

        public MagazineState GetMagazineState(int n)
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
        public ObservableCollection<MagazineState> GetAllMagazineStates()
        {
            return dataContext.magazineStates;
        }

        public void UpdateMagazineState(MagazineState magazineState, Product product, int amount)
        {
            magazineState.Product = product;
            magazineState.Amount = amount;

        }

        public void DeleteMagazineState(MagazineState magazineState)
        {
            for (int i = 0; i < dataContext.magazineStates.Count; i++)
            {
                if (magazineState == dataContext.magazineStates[i])
                {
                    dataContext.magazineStates.RemoveAt(i);
                }
            }
        }

        public void AddBill(int amountBought, Client client, MagazineState magazineState, Product product)
        {
            Bill bill = new Bill(amountBought, client, magazineState, product);
            dataContext.bills.Add(bill);
        }

        public Bill GetBill(int n)
        {
            for (int i = 0; i < dataContext.bills.Count; i++)
            {
                if (n == i)
                {
                    return dataContext.bills[i];
                }
            }
            return null;
        }
        public ObservableCollection<Bill> GetAllBills()
        {
            return dataContext.bills;
        }
        public void UpdateBill(Bill bill, int amount, Client client, MagazineState magazineState, Product product)
        {
            bill.Amount = amount;
            bill.Client = client;
            bill.MagazineState = magazineState;
            bill.Product = product;
        }

        public void DeleteBill(Bill bill)
        {
            for (int i = 0; i < dataContext.bills.Count; i++)
            {
                if (bill == dataContext.bills[i])
                {
                    dataContext.bills.RemoveAt(i);
                }
            }
        }

        public void AddRestock(int amount, MagazineState magazineState, Product product)
        {
            Restock restock = new Restock(amount, magazineState, product);
            dataContext.restocks.Add(restock);
        }

        public Restock GetRestock(int n)
        {
            for (int i = 0; i < dataContext.restocks.Count; i++)
            {
                if (n == i)
                {
                    return dataContext.restocks[i];
                }
            }
            return null;
        }
        public ObservableCollection<Restock> GetAllRestocks()
        {
            return dataContext.restocks;
        }
        public void UpdateRestock(Restock restock, int amount, MagazineState magazineState, Product product)
        {
            restock.Amount = amount;
            restock.MagazineState = magazineState;
            restock.Product = product;
        }

        public void DeleteRestock(Restock restock)
        {
            for (int i = 0; i < dataContext.restocks.Count; i++)
            {
                if (restock == dataContext.restocks[i])
                {
                    dataContext.restocks.RemoveAt(i);
                }
            }
        }

        public void FillClients()
        {
            List<string> firstNameList = new List<string>();
            List<string> sureNameList = new List<string>();

            firstNameList = DataFiller.readElementFromFile("firstName");
            sureNameList = DataFiller.readElementFromFile("surName");

            for (int i = 0; i < firstNameList.Count; i++)
            {
                AddClient(firstNameList[i], sureNameList[i]);
            }

        }
        public void FillProducts()
        {
            List<string> guidList = new List<string>();
            List<string> costList = new List<string>();
            List<string> productNameList = new List<string>();

            guidList = DataFiller.readElementFromFile("guid");
            costList = DataFiller.readElementFromFile("cost");
            productNameList = DataFiller.readElementFromFile("productName");

            for (int i = 0; i < guidList.Count; i++)
            {
                AddProduct(Guid.Parse(guidList[i]), double.Parse(costList[i], CultureInfo.InvariantCulture), productNameList[i]);
            }

        }
    }
}