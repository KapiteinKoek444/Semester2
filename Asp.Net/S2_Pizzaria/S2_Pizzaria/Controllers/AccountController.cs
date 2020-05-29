using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Logic_Layer.Entities.Users;
using Logic_Layer.Factory;
using Logic_Layer.Manager;
using Logic_Layer.Models;

namespace S2_Pizzaria.Controllers
{
	public class AccountController : Controller
	{
		UserManager manager = new UserManager();

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginModel customer)
		{
			var user = manager.Users.Where(x => x.Password == customer.Password && x.UName == customer.Uname).FirstOrDefault();


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

		public ActionResult RegisterUser()
		{
			return View();
		}

		[HttpPost]
		public ActionResult RegisterUser(UserModel customerModel)
		{
			var customer = UserModelFactory.ConvertUser(customerModel);
			manager.AddCustomer(customer);
			return View();
		}
	}
}