using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic_Layer.Entities.Users;
using Logic_Layer.Factory;
using Logic_Layer.Manager;
using Logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace S2_Pizzaria.Controllers
{
	public class AccountController : Controller
	{
		CustomerManager manager = new CustomerManager();

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginModel customer)
		{
			var user = manager.Customers.Where(x => x.Password == customer.Password && x.UName == customer.Uname).FirstOrDefault();


			if (user != null)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "Invalid user/pass");
				return View();
			}
		}

		public IActionResult RegisterUser()
		{
			return View();
		}

		[HttpPost]
		public IActionResult RegisterUser(CustomerModel customerModel)
		{
			var customer = UserModelFactory.ConvertCustomer(customerModel);
			manager.AddCustomer(customer);
			return View();
		}

		public IActionResult RegisterEmployee()
		{
			return View();
		}
	}
}