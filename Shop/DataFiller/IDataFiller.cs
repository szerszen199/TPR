using Shop;
using System.Collections.Generic;

namespace Shop.DataFiller
{
    public interface IDataFiller
    {
        List<string> readElementFromFile(string xmlElementName);
    }
}