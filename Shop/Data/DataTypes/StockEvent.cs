namespace Shop.Data.DataTypes
{
    public abstract class StockEvent
    {

        public int Amount { get; set; }
        public IMagazineState MagazineState { get; set; }
        public IProduct Product { get; set; }
        public double Price { get; set; }

        public StockEvent(int amount, IMagazineState magazineState, IProduct product)
        {
            Amount = amount;
            MagazineState = magazineState;
            Product = product;
            Price = amount * product.Cost;
        }
    }
}