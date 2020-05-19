using Logic_Layer.Entities.Users;
using Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Factory
{
	public static class UserFactory
	{
		public static List<CustomerModel> ConvertCustomer(List<Customer> customers)
		{
			List<CustomerModel> custModels = new List<CustomerModel>();

			foreach (var customer in customers)
			{
				var customerMod = ConvertCustomer(customer);
				custModels.Add(customerMod);
			}
			return custModels;
		}

		public static CustomerModel ConvertCustomer(Customer customer)
		{
			CustomerModel customerMod = new CustomerModel
			{
				UName = customer.UName,
				Password = customer.Password,
				Email = customer.Email,
				ZipCode = customer.Adress.ZipCode,
				HouseNr = customer.Adress.HousNr,
			};

			return customerMod;
		}

		public static List<EmployeeModel> ConvertEmployee(List<Employee> employees)
		{
			List<EmployeeModel> employeeMod = new List<EmployeeModel>();

			foreach (var employee in employees)
			{
				var customerMod = ConvertEmployee(employee);
				employeeMod.Add(customerMod);
			}
			return employeeMod;
		}

		public static EmployeeModel ConvertEmployee(Employee employee)
		{
			EmployeeModel EmployeeMod = new EmployeeModel
			{
				UName = employee.UName,
				Password = employee.Password,
				Email = employee.Email,
			};

			return EmployeeMod;
		}
	}
}
