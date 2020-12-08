using Newtonsoft.Json;
using Shop.Data;
using Shop.Data.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Shop.Data
{
    public class Deserialize
    {

        public List<IClient> JSONToClient(string path)
        {
            string json = System.IO.File.ReadAllText(@path);
            return JsonConvert.DeserializeObject<List<IClient>>(json, new JsonSerializerSettings 
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore});
            
        }
        public Dictionary<Guid, IProduct> JSONToProduct(string path)
        {
            string json = System.IO.File.ReadAllText(@path);
            return JsonConvert.DeserializeObject<Dictionary<Guid, IProduct>>(json, new JsonSerializerSettings
            {   PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
            
        }

        public ObservableCollection<IMagazineState> JSONToMagazineState(string path)
        {
            string json = System.IO.File.ReadAllText(@path);
            return JsonConvert.DeserializeObject<ObservableCollection<IMagazineState>>(json, new JsonSerializerSettings
            {   PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
            
        }

        public ObservableCollection<StockEvent> JSONToStockEvent(string path)
        {
            string json = System.IO.File.ReadAllText(@path);
            return JsonConvert.DeserializeObject<ObservableCollection<StockEvent>>(json, new JsonSerializerSettings
            {   PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
            
        }

        public List<IClient> CSVToClients(string path)
        {
            string[] fileString = System.IO.File.ReadAllLines(@path);
            List<IClient> clients = new List<IClient>();
            foreach (string line in fileString)
            {
                string[] words = line.Split(';');
                clients.Add(new Client(words[0], words[1]));
            }
            return clients;
        }

        public Dictionary<Guid, IProduct> CSVToProducts(string path)
        {
            string[] fileString = System.IO.File.ReadAllLines(@path);
            Dictionary<Guid, IProduct> products = new Dictionary<Guid, IProduct>();
            foreach (string line in fileString)
            {
                string[] words = line.Split(';');
                Guid ProductGuid = new Guid(words[0]);
                products.Add(ProductGuid, new Product( ProductGuid, Double.Parse(words[1], CultureInfo.InvariantCulture), words[2]));
            }
            return products;
        }

    }
}    
