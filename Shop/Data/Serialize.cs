using Newtonsoft.Json;
using Shop.Data.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Shop.Data
{
    public class Serialize
    {
        JsonSerializer serializer = new JsonSerializer();
       
        StreamWriter sw = new StreamWriter(@"C:\Users\szers\Source\Repos\TPR\Shop\Data\json.txt");


        public Serialize(DataContext dataContext)
        {
            serializer.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.Objects;
            serializer.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, dataContext, typeof(DataContext));
            }

        }

/*        public Serialize(List<IClient> clients)
        {
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, clients);
            }
            
        }
        public Serialize(Dictionary<Guid, IProduct> products)
        {
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, products);
            }
        }

        public Serialize(ObservableCollection<IMagazineState> magazineStates)
        {
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, magazineStates);
            }
        }
        public Serialize(ObservableCollection<StockEvent> stockEvents)
        {
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, stockEvents);
            }
        }*/
    }
}
