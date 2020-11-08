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

namespace Shop.DataFiller
{

    public class FillFromFile : IDataFiller
    {

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
