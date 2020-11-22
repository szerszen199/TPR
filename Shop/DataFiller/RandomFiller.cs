using Shop.DataFiller;
using Shop.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataFiller
{
    public class RandomFiller : IDataFiller
    {
        public int RandomInt(int range)
        {
            Random random = new Random();
            return random.Next(0, range);
        }

        public void Fill(DataContext context)
        {
            List<string> randomProductGUIDList = new List<string> { "e834cf80-3af7-4271-8cba-4c700bcc7804",
                "f8982011-36a8-4b0d-a5a0-e54e20e07de8", "3952af6b-edb7-4af4-b33d-f95b4579a806", "48badb51-c34c-46b7-999f-a14dcf2b89e3",
                "532f09a7-3d2f-4a58-be44-8268870dae96", "3a7d29f5-332a-48ab-98c3-9846a0caa22f", "a3e853ab-741f-467a-a71a-c6fc57d52575",
                "e76cda00-39b1-4af1-aeda-da2f389a38a7", "6189a733-6d29-4822-aead-20cd10effd89", "c9e45ded-a65c-47fc-a640-142fa49e99bc",
                "e73b134a-7bfd-46ab-97e5-9fe204d3e56b", "1b4ea360-d2df-45dc-9089-8f825517f4c1", "25144b5a-13c1-4fed-b8e2-86b41ac0197b",
                "fe44303b-e206-4515-9539-fb4fa57e6737", "7f581a77-376f-441b-836a-dd0c181faf8a", "61a959dc-ac33-4e64-a072-3e1c5da74e1b",
                "5d17263b-067d-48a9-89b1-d880dea498f0", "c638ea4a-8ada-4787-8004-b8b17f4006e1", "4a41b1df-73e6-4d7a-8765-ab68d07cacd7",
                "014e9b5c-cd86-4be5-a79a-fe8ab5034660", "8ba14e29-c1f8-4c59-924b-97a9047c9ea1", "0292bcbd-54ed-4cff-8c51-8f7faada67ae",
                "9278c0bc-c0cf-4053-bfa9-7dc3e89558c6", "7f0c7311-0bd0-4a86-a226-fd2fe372fcf7", "fa466104-05cd-44ba-a1f2-4da8f5ad9dc7"};

            List<string> randomProductNameList = new List<string> { "Muffins - Assorted", "Ham - Cooked", "Flour - Rye",
                "Cheese - Ermite Bleu", "Crab - Imitation Flakes", "Cookie Choc", "Walkers Special Old Whiskey",
                "Cheese - Roquefort Pappillon", "Squid U5 - Thailand", "Buffalo - Tenderloin", "Mushroom - Lg - Cello",
                "Carbonated Water - Orange", "Rabbit - Legs", "Mushroom - Porcini Frozen", "Grapes - Green",
                "Trout Rainbow Whole", "Muffin Chocolate Individual Wrap", "Clam Nectar", "Cheese - Goat",
                "Mushroom - Lg - Cello", "Cleaner - Lime Away", "Tart Shells - Savory, 2", "Lemon Balm - Fresh", "Guava",
                "Sugar - Invert"};

            List<double> randomProductCostList = new List<double> { 57.42, 26.63, 16.03, 98.62, 83.99, 69.16, 78.72, 77.8,
                32.15, 34.84, 97.42, 96.53, 57.25, 54.01, 36.95, 39.23, 99.65, 19.42, 54.28, 49.88, 26.53, 12.86, 35.82,
                82.88, 53.23, };


            List<string> firstNameList = new List<string>() { "Mab", "Abbot", "Arley", "Sandy", "Nata", "Yorgos"
                , "Jemimah", "Sherwynd", "Colby", "Augusta", "Heinrik", "Ferguson", "Emmery", "Claudina", "Cindra"
                , "Nelli", "Nerissa", "Bridget", "Greer", "Michell", "Lowe", "Angie", "Chadwick", "Faina" };

            List<string> sureNameList = new List<string>() { "Tschierasche", "Dowrey", "Axell", "Dyshart", "Seago",
                "Cannings", "Nursey", "Earsman", "Shoebottom", "Wherry", "Valentinetti", "Dur", "Mustarde", "Halburton",
                "McKenzie", "Ruzek", "Scanes", "McIlmurray", "Jerdein", "Hardware", "Tattam", "Aers", "Lupton", "Vittet",
                "Estrella" };
            
            context.clients.Add(new Client(firstNameList[RandomInt(firstNameList.Count())], sureNameList[RandomInt(firstNameList.Count())]));
            context.clients.Add(new Client(firstNameList[RandomInt(firstNameList.Count())], sureNameList[RandomInt(firstNameList.Count())]));
            context.clients.Add(new Client(firstNameList[RandomInt(firstNameList.Count())], sureNameList[RandomInt(firstNameList.Count())]));
            context.clients.Add(new Client(firstNameList[RandomInt(firstNameList.Count())], sureNameList[RandomInt(firstNameList.Count())]));
            context.clients.Add(new Client(firstNameList[RandomInt(firstNameList.Count())], sureNameList[RandomInt(firstNameList.Count())]));
            context.clients.Add(new Client(firstNameList[RandomInt(firstNameList.Count())], sureNameList[RandomInt(firstNameList.Count())]));
            context.clients.Add(new Client(firstNameList[RandomInt(firstNameList.Count())], sureNameList[RandomInt(firstNameList.Count())]));

            Guid Guid1 = Guid.NewGuid();
            context.products.Add(Guid1, new Product(Guid1, randomProductCostList[RandomInt(randomProductCostList.Count())], randomProductNameList[RandomInt(randomProductNameList.Count())]));
            Guid Guid2 = Guid.NewGuid();
            context.products.Add(Guid2, new Product(Guid2, randomProductCostList[RandomInt(randomProductCostList.Count())], randomProductNameList[RandomInt(randomProductNameList.Count())]));
            Guid Guid3 = Guid.NewGuid();
            context.products.Add(Guid3, new Product(Guid3, randomProductCostList[RandomInt(randomProductCostList.Count())], randomProductNameList[RandomInt(randomProductNameList.Count())]));

            context.magazineStates.Add(new MagazineState(context.products[Guid1], RandomInt(100)));
            context.magazineStates.Add(new MagazineState(context.products[Guid2], RandomInt(100)));
            context.magazineStates.Add(new MagazineState(context.products[Guid3], RandomInt(100)));

            context.stockEvents.Add(new Bill(4, context.clients[0], context.magazineStates[0], context.products[Guid1]));
            context.stockEvents.Add(new Bill(1, context.clients[1], context.magazineStates[1], context.products[Guid2]));
            context.stockEvents.Add(new Restock(5, context.magazineStates[1], context.products[Guid2]));
        }
    }
}

