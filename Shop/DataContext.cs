using System;
using System.Collections.Generic;
using Shop.DataTypes;

namespace Shop
{
	public class DataContext
	{
		public List<Bill> bills = new List<Bill>();
		public List<Client> clients = new List<Client>();
		public List<MagazineState> magazineStates = new List<MagazineState>();
		public List<Product> products = new List<Product>();
		public DataContext()
		{
		}
	}
}

