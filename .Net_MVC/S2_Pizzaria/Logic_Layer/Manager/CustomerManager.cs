using Logic_Layer.Entities.Users;
using Logic_Layer.Factory;
using Logic_Layer.TemporaryData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Manager
{
	public class CustomerManager
	{
		public TemporaryUserBuilder userBuilder = new TemporaryUserBuilder();
		public List<Customer> Customers { get; set; }

		public CustomerManager()
		{
			Customers = userBuilder.customers;
		}

		public Customer GetCustomerById(int id)
		{
			Customer customer = Customers[id + 1];
			return customer;
		}

		public List<Customer> GetAllCustomers()
		{
			return Customers;
		}

		public Customer EditCustomer(int id, Customer newCustomer)
		{
			Customers[id + 1] = newCustomer;
			return Customers[id + 1];
		}

		public Customer AddCustomer(Customer customer)
		{
			Customers.Add(customer);
			return customer;
		}

		public void RemoveCustomer(int id)
		{
			Customers.RemoveAt(id + 1);
		}
	}
}
