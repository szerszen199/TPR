using System;
using System.Reflection;

public class Bill
{
    public int amountBought { get; set; }
    public Client client { get; set; };
    public MagazineState magazineState { get; set; };
    public Product product { get; set; };

    public Bill()
	{
	}
}
