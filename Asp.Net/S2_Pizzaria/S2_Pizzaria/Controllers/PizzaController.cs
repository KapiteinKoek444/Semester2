using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Logic_Layer.Entities.Pizza_Components;

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

        public ActionResult CustomizePizza(Pizza pizza)
        {
            return View();
        }
    }
}