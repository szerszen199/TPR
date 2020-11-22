using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shop.DataTypes;

namespace Shop
{
	public class DataContext
	{
		public ObservableCollection<StockEvent> stockEvents = new ObservableCollection<StockEvent>();
		public List<IClient> clients = new List<IClient>();
		public ObservableCollection<IMagazineState> magazineStates = new ObservableCollection<IMagazineState>();
		public Dictionary<Guid, IProduct> products = new Dictionary<Guid, IProduct>();
		public DataContext()
		{
		}
	}
}

