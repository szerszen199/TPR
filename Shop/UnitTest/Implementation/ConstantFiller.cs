using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Data.DataFiller;
using Shop.Data;
using Shop.Data.DataTypes;

namespace DataTests
{
    public class ConstantFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            context.clients.Add(new Client("Grzegorz", "Muszynski"));
            context.clients.Add(new Client("Tomasz", "Wozniak"));

            Guid Guid1 = Guid.Parse("3EA13DB8-DCB3-4ED9-805C-B88AA99AB5C5");
            Guid Guid2 = Guid.Parse("B7810043-50A9-405D-97B0-19E8B0154B58");
            Guid Guid3 = Guid.Parse("6D5A44F8-AE83-44C8-A15E-A4525450C907");

            context.products.Add(Guid1, new Product(Guid1, 10.98, "Table"));
            context.products.Add(Guid2, new Product(Guid2, 17.53, "Chair"));
            context.products.Add(Guid3, new Product(Guid3, 35.04, "Desk"));

            context.magazineStates.Add(new MagazineState(context.products[Guid1], 10));
            context.magazineStates.Add(new MagazineState(context.products[Guid2], 5));
            context.magazineStates.Add(new MagazineState(context.products[Guid3], 7));

            context.stockEvents.Add(new Bill(4, context.clients[0], context.magazineStates[0], context.products[Guid1]));
            context.stockEvents.Add(new Bill(1, context.clients[1], context.magazineStates[1], context.products[Guid2]));
            context.stockEvents.Add(new Restock(5, context.magazineStates[1], context.products[Guid2]));


        }
    }
}

