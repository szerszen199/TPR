using Newtonsoft.Json;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shop.Data
{
    public class Deserialize
    {
        DataContext dataContext;

        public Deserialize()
        {
            using (StreamReader file = File.OpenText(@"C:\Users\szers\Source\Repos\TPR\Shop\Data\json.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                this.dataContext = (DataContext)serializer.Deserialize(file, typeof(DataContext));
            }
        }
        public DataContext getDeserializeContex()
        {
            return dataContext;
        }
    }    
}
