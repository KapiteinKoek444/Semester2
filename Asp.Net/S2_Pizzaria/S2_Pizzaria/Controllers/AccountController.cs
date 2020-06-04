using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLogic.Factory;
using BusinessLogic.Manager;
using BusinessLogic.Manager.User;
using BusinessLogic.Models;

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
			manager.GetUser(customer.Uname, customer.Password);
			return View();
		}

		public ActionResult RegisterUser()
		{
			return View();
		}

		[HttpPost]
		public ActionResult RegisterUser(UserModel UserModel)
		{
			manager.AddUser(UserModel);
			return View();
		}
	}
}