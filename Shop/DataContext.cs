using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shop.DataTypes;

namespace Shop
{
	public class DataContext
	{
		public ObservableCollection<Bill> bills = new ObservableCollection<Bill>();
        public ObservableCollection<Restock> restocks = new ObservableCollection<Restock>();
		public List<Client> clients = new List<Client>();
		public ObservableCollection<MagazineState> magazineStates = new ObservableCollection<MagazineState>();
		public Dictionary<Guid, Product> products = new Dictionary<Guid, Product>();
		public DataContext()
		{
		}
	}
}

