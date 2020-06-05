using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic.Factory;
using BusinessLogic.Manager;
using BusinessLogic.Manager.User;
using BusinessLogic.Models;

namespace S2_Pizzaria.Controllers
{
	public class AccountController : Controller
	{
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginModel customer)
		{
			var user = UserManager.GetUser(customer.Uname, customer.Password);

			if (user == null)
				return View();

			FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
			return RedirectToAction("Index", "Home");
		}

		public ActionResult RegisterUser()
		{
			return View();
		}

		[HttpPost]
		public ActionResult RegisterUser(UserModel UserModel)
		{
			var user = UserManager.AddUser(UserModel);
			if (user == null)
				return View();

			FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
			return RedirectToAction("Index", "Home");
		}	
	}
}