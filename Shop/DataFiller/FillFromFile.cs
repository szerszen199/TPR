using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
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


        public void Fill(DataContext context)
        {
            FillClients(context);
            FillProducts(context);
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

        public void FillClients(DataContext context)
        {
            List<string> firstNameList = new List<string>();
            List<string> sureNameList = new List<string>();

            firstNameList = readElementFromFile("firstName");
            sureNameList = readElementFromFile("surName");

            for (int i = 0; i < firstNameList.Count; i++)
            {
                context.clients.Add(new Client(firstNameList[i], sureNameList[i]));
            }
        }
        public void FillProducts(DataContext context)
        {
            List<string> guidList = new List<string>();
            List<string> costList = new List<string>();
            List<string> productNameList = new List<string>();

            guidList = readElementFromFile("guid");
            costList = readElementFromFile("cost");
            productNameList = readElementFromFile("productName");

            for (int i = 0; i < guidList.Count; i++)
            {
                context.products.Add(Guid.Parse(guidList[i]), new Product(Guid.Parse(guidList[i]), double.Parse(costList[i], CultureInfo.InvariantCulture), productNameList[i]));
            }

        }


    }
}
