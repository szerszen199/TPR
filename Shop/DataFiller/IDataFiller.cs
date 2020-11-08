using Shop;
using System.Collections.Generic;

namespace Shop.DataFiller
{
    public interface IDataFiller
    {
        void Fill(DataContext context);
    }
}