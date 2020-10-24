using System;
using System.Collections.Generic;
using Shop.DataTypes;

namespace Shop
{
	public class DataContext
	{
		List<Bill> bills= new List<Bill>();
		List<Client> clients = new List<Client>();
		List<MagazineState> magazineStates = new List<MagazineState>();
		List<Product> products = new List<Product>();

		public DataContext()
		{
		}
	}
}

