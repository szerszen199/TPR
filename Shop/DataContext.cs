using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shop.DataTypes;

namespace Shop
{
	public class DataContext
	{
		public List<Bill> bills = new List<Bill>();
        public List<Restock> restocks = new List<Restock>();
		public List<Client> clients = new List<Client>();
		public ObservableCollection<MagazineState> magazineStates = new ObservableCollection<MagazineState>();
		public Dictionary<Guid, Product> products = new Dictionary<Guid, Product>();
		public DataContext()
		{
		}
	}
}

