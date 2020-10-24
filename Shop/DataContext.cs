using System;
using System.Collections.Generic;
using Shop.Datatypes;

namespace Shop
{
	public class DataContext
	{
		Bill bills = new List<Bill>();
		Clitent clients = new List<Client>();
		MagazineState magazineStates = new List<MagazineState>();
		Product products = new List<Product>();

		public DataContext()
		{
		}
	}
}

