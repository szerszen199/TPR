namespace Shop.DataTypes
{
    public interface IBill
    {
        int AmountBought { get; set; }
        Client Client { get; set; }
        MagazineState MagazineState { get; set; }
        double Paid { get; set; }
        Product Product { get; set; }
    }
}