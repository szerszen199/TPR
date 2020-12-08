using Newtonsoft.Json;
using Shop.Data;
using Shop.Data.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Shop.Data
{
    class Serialize
    {
        public void SerializeToJSON(List<IClient> clients, string path)
        {
            string json = JsonConvert.SerializeObject(clients, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings 
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
            System.IO.File.WriteAllText(@path, json);
        }
        public void SerializeToJSON(Dictionary<Guid, IProduct> products, string path)
        {
            string json = JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings 
            {   PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
            System.IO.File.WriteAllText(@path, json);
        }
        public void SerializeToJSON(ObservableCollection<IMagazineState> magazineStates, string path)
        {
            string json = JsonConvert.SerializeObject(magazineStates, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings 
            {   PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
            System.IO.File.WriteAllText(@path, json);
        }
        public void SerializeToJSON(ObservableCollection<StockEvent> stockEvents, string path)
        {
            string json = JsonConvert.SerializeObject(stockEvents, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {   PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
            System.IO.File.WriteAllText(@path, json);
        }


        public void SerializeToJSON(IDataRepository data)
        {
            SerializeToJSON(data.GetAllClients(), "Clients.json");
            SerializeToJSON(data.GetAllProducts(), "Products.json");
            SerializeToJSON(data.GetAllMagazineStates(), "MagazineStates.json");
            SerializeToJSON(data.GetAllStockEvents(), "StockEvents.json");
        }

        public void SerializeToCSV(List<IClient> clients, string path)
        {
            string line = "";
            foreach (Client client in clients)
            {
                line += client.FirstName + ';' + client.SurName +"\n";
            }
            System.IO.File.WriteAllText(@path, line);
        }
        public void SerializeToCSV(Dictionary<Guid, IProduct> products, string path)
        {
            string linia = "";
            foreach (KeyValuePair<Guid, IProduct> product in products)
            {
                linia += product.Value.Guid.ToString() + ';' + product.Value.Cost + ';' + product.Value.ProductName + "\n";
            }
            System.IO.File.WriteAllText(@path, linia);
        }

        public void SerializeToCSV(ObservableCollection<IMagazineState> magazineStates, string path)
        {
            string linia = "";
            foreach (IMagazineState magazineState in magazineStates)
            {
                linia += magazineState.Guid.ToString() + ';' + magazineState.Product + ';' + magazineState.Amount + ';' + "\n";
            }
            System.IO.File.WriteAllText(@path, linia);
        }

        public void SerializeToCSV(ObservableCollection<StockEvent> stockEvents, string path)
        {
            string linia = "";
            foreach (StockEvent stockEvent in stockEvents)
            {
                linia += stockEvent.Product.ToString() + ';' + stockEvent.Price.ToString() + ';' + stockEvent.Amount + ';' + stockEvent.MagazineState + "\n";
            }
            System.IO.File.WriteAllText(@path, linia);
        }
        public void SerializeToCSV(IDataRepository data)
        {
            SerializeToCSV(data.GetAllClients(), "Clients.csv");
            SerializeToCSV(data.GetAllProducts(), "Products.csv");
            SerializeToCSV(data.GetAllMagazineStates(), "MagazineStates.csv");
            SerializeToCSV(data.GetAllStockEvents(), "StockEvents.csv");
        }
    }
}