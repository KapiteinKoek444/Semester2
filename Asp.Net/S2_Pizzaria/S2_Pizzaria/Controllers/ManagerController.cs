using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2_Pizzaria.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult ManageIngredients()
        {
            return View();
        }

        public ActionResult AddIngredient()
        {
            return View();
        }

        public ActionResult ManagePizzas()
        {
            return View();
        }

        public ActionResult AddPizza()
        {
            return View();
        }
    }
}