
namespace Shop.Data.DataTypes
{
    public interface IBill
    {
        IClient Client { get; set; }
        int Amount { get; set; }
        IMagazineState MagazineState { get; set; }
        IProduct Product { get; set; }
        double Price { get; set; }
    }
}