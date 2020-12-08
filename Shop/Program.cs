using Shop.Data;
using System;
using System.IO;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Operations: ");
            Console.WriteLine("1. Export to JSON");
            Console.WriteLine("2. Import from JSON");
            int choice = Console.Read() - '0';

            IDataRepository dataRepository = new DataRepository(new ConsoleFiller());
            IDataRepository dataRepositoryDeserialized = new DataRepository(new ConsoleFiller());
            dataRepository.Fill();
            Serialize serialize = new Serialize();
            Deserialize deserialize = new Deserialize();
            switch (choice)
            {
                case 1:
                    serialize.SerializeToJSON(dataRepository);
                    Console.WriteLine("Successfully serialized!");
                    break;
                case 2:
                    try
                    {
                        dataRepositoryDeserialized.SetAllClients(deserialize.JSONToClient("Clients.json"));
                        dataRepositoryDeserialized.SetAllProducts(deserialize.JSONToProduct("Products.json"));
                        dataRepositoryDeserialized.SetAllMagazineStates(deserialize.JSONToMagazineState("MagazineStates.json"));
                        dataRepositoryDeserialized.SetAllStockEvents(deserialize.JSONToStockEvent("StockEvents.json"));
                        Console.WriteLine("Successfully deserialized!");
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Error: " + e.GetType());
                    }
                    break;
                default:
                    break;
            }


            Console.ReadKey();
        }
    }
}