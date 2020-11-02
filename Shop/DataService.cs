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
        public void addNewClient(string firstname, string surName)
        {
            dataRepository.AddClient(firstname, surName);
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
            Console.WriteLine($"Products: ");
            foreach (KeyValuePair<Guid, Product> product in dataRepository.GetAllProducts())
            {
                Console.WriteLine("Guid = {0}, Cost = {1}, ProductName = {2}", product.Value.Guid, product.Value.Cost, product.Value.ProductName);
            }

        }
        public void showAllMagazineStates()
        {
            Console.WriteLine($"Magazine States: ");
            ObservableCollection<MagazineState> colection = dataRepository.GetAllMagazineStates();

            for (int i = 0; i < colection.Count; i++)
            {
                Console.WriteLine($"{i}. Guid = {colection[i].Guid}, Product = {colection[i].Product.ProductName}, Amount = {colection[i].Amount}");
            }

        }
        public void showAllBills()
        {
            Console.WriteLine($"Bills : ");
            List<IBill> colection = dataRepository.GetAllBills();

            for (int i = 0; i < colection.Count; i++)
            {
                Console.WriteLine($"{i}. Client = {colection[i].Client.FirstName} {colection[i].Client.SurName}, Product = {colection[i].Product.ProductName}, Amount = {colection[i].AmountBought}, Paid = {colection[i].Paid}");
            }

        }
        public void showAllClients()
        {
            Console.WriteLine($"Clients : ");
            List<Client> colection = dataRepository.GetAllClients();

            for (int i = 0; i < colection.Count; i++)
            {
                Console.WriteLine($"{i}. Client = {colection[i].FirstName} {colection[i].SurName}");
            }
        }
/*        public void fillProgram()
        {
            dataRepository.bills.Add();
        }*/
    }
}
