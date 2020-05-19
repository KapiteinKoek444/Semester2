using Logic_Layer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.TemporaryData
{
	public class TemporaryUserBuilder
	{
		public List<Customer> customers = new List<Customer>();
		public List<Employee> employees = new List<Employee>();

		public TemporaryUserBuilder()
		{
			GenerateCustomers(1);
			GenerateEmployees(1);
		}

		private void GenerateEmployees(int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				Customer customer = new Customer("Matthijs", "wachtwoord", "test@test.test", new Adress("grasparkiet", 4));
				customers.Add(customer);
			}
		}

		private void GenerateCustomers(int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				Employee employee = new Employee("Jeroen", "wachtwoordjuu", "jeroen@test.test");
				employees.Add(employee);
			}
		}
	}
}
