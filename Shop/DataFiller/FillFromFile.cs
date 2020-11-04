using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Shop;
using Shop.DataTypes;

namespace ShopProject.Shop.DataFiller
{

    public class FillFromFile : IDataFiller
    {
/*        DataRepository dataRepository;
        public FillFromFile(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }*/
        public FillFromFile()
        {
        }

        public List<string> readElementFromFile(string xmlElementName)
        {
            XDocument doc = XDocument.Load(@"Shop\DataFiller\dataset.xml");
            List<string> lista = new List<string>();

            var elements = doc.Descendants(xmlElementName);

            foreach (var element in elements)
            {
                lista.Add(element.Value);
            }
            return lista;
        }
    }
}
