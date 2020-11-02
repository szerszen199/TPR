using Shop;
using System.Collections.Generic;

namespace ShopProject.Shop.DataFiller
{
    public interface IDataFiller
    {
        List<string> readElementFromFile(string xmlElementName);
    }
}