using System.Collections.Generic;

namespace Shop.Data
{
    public interface IDataFiller
    {
        void Fill(DataContext context);

    }
}