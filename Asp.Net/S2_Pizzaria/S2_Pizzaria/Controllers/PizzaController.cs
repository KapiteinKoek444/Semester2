using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace S2_Pizzaria.Controllers
{
    public class PizzaController : Controller
    {
        public ActionResult PizzaList()
        {
            return View();
        }

        public ActionResult CreatePizza()
        {
            return View();
        }

        public ActionResult CustomizePizza()
        {
            return View();
        }
    }
}