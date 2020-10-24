using System;
using Shop.DataTypes;
using System.Collections.Generic;
namespace Shop
{
	public class DataRepository
	{
		public DataContext dataContext = new DataContext();

		public void AddProduct(double Cost, string ProductName)
        {
			Product product = new Product(Cost, ProductName); 
			dataContext.products.Add(product);
		}

		public Product GetProduct(int n)
		{
			for(int i=0;i<dataContext.products.Count;i++)
            {
				if (n == i)
                {
					return dataContext.products[i];
                }
			}
			return null;
		}

		public void UpdateProduct(Product product, double cost, string productName)
		{
			product.Cost = cost;
			product.ProductName = productName;
			
		}

		public void DeleteProduct(Product product)
        {
			for (int i = 0; i < dataContext.products.Count; i++)
			{
				if (product == dataContext.products[i])
				{
					dataContext.products.RemoveAt(i);
				}
			}
		}

		public void AddClient()
		{
			Client client = new Client();
			dataContext.clients.Add(client);
		}

		public Client GetClient(Client client)
		{
			for (int i = 0; i < dataContext.clients.Count; i++)
			{
				if (client == dataContext.clients[i])
				{
					return dataContext.clients[i];
				}
			}
			return null;
		}

		public void UpdateClient(Client client, string firstName, string surName)
		{
			client.FirstName = firstName;
			client.SurName = surName;

		}

		public void DeleteClient(Client client)
		{
			for (int i = 0; i < dataContext.clients.Count; i++)
			{
				if (client == dataContext.clients[i])
				{
					dataContext.clients.RemoveAt(i);
				}
			}
		}

		public void AddMagazineState()
		{
			MagazineState magazineState = new MagazineState();
			dataContext.magazineStates.Add(magazineState);
		}

		public MagazineState GetMagazineState(MagazineState magazineState)
		{
			for (int i = 0; i < dataContext.magazineStates.Count; i++)
			{
				if (magazineState == dataContext.magazineStates[i])
				{
					return dataContext.magazineStates[i];
				}
			}
			return null;
		}

		public void UpdateMagazineState(MagazineState magazineState, Product product, int amount)
		{
			magazineState.product = product;
			magazineState.Amount = amount;

		}

		public void DeleteMagazineState(MagazineState magazineState)
		{
			for (int i = 0; i < dataContext.magazineStates.Count; i++)
			{
				if (magazineState == dataContext.magazineStates[i])
				{
					dataContext.magazineStates.RemoveAt(i);
				}
			}
		}

		public void AddBill()
		{
			Bill bill = new Bill();
			dataContext.bills.Add(bill);
		}

		public Bill GetBill(Bill bill)
		{
			for (int i = 0; i < dataContext.bills.Count; i++)
			{
				if (bill == dataContext.bills[i])
				{
					return dataContext.bills[i];
				}
			}
			return null;
		}

		public void UpdateBill(Bill bill, int amountBought, Client client, MagazineState magazineState, Product product)
		{
			bill.amountBought = amountBought;
			bill.client = client;
			bill.magazineState = magazineState;
			bill.product = product;
		}

		public void DeleteBill(Bill bill)
		{
			for (int i = 0; i < dataContext.bills.Count; i++)
			{
				if (bill == dataContext.bills[i])
				{
					dataContext.bills.RemoveAt(i);
				}
			}
		}

	}
}