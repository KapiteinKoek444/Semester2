using Logic_Layer.Entities.Users;
using Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.Factory
{
	public static class UserModelFactory
	{
		public static List<Customer> ConvertCustomer(List<CustomerModel> customerModels)
		{
			List<Customer> customers = new List<Customer>();

			foreach (var customerModel in customerModels)
			{
				var customerMod = ConvertCustomer(customerModel);
				customers.Add(customerMod);
			}
			return customers;
		}

		public static Customer ConvertCustomer(CustomerModel cusModel)
		{
			Customer customer = new Customer(cusModel.UName, cusModel.Password, cusModel.Email, new Adress(cusModel.ZipCode, cusModel.HouseNr));
			return customer;
		}

		public static List<Employee> ConvertEmployee(List<EmployeeModel> employeeModels)
		{
			List<Employee> employees = new List<Employee>();

			foreach (var employeeModel in employeeModels)
			{
				var employee = ConvertEmployee(employeeModel);
				employees.Add(employee);
			}
			return employees;
		}

		public static Employee ConvertEmployee(EmployeeModel employeeModel)
		{
			Employee employee = new Employee(employeeModel.UName, employeeModel.Password, employeeModel.Email);
			return employee;
		}
	}
}
