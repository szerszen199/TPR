using System.Collections.Generic;

namespace Shop.Data.DataFiller
{
    public interface IDataFiller
    {
        void Fill(DataContext context);

    }
}