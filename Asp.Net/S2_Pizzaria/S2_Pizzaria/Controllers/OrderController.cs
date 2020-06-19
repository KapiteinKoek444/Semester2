using BusinessLogic.Manager.Pizza;
using BusinessLogic.Manager.User;
using BusinessLogic.Models;
using BusinessLogic.Models.IngredientComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2_Pizzaria.Controllers
{
    public class OrderController : Controller
    {
        PizzaModel pizzaModel = new PizzaModel();
        BottomModel bottomModel = new BottomModel();
        SauceModel sauceModel = new SauceModel();
        List<IngredientModel> ingredientModel = new List<IngredientModel>();

        public ActionResult PizzaBasePicker()
        {
            var models = PizzaManager.getAllPizzas();
            return View(models);
        }

        [HttpPost]
        public ActionResult PizzaBasePicker(PizzaModel model)
        {
            pizzaModel = model;
            return RedirectToAction("BottomPicker");
        }

        public ActionResult BottomPicker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BottomPicker(BottomModel model)
        {
            bottomModel = model;
            return RedirectToAction("SaucePicker");
        }

        public ActionResult SaucePicker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaucePicker(SauceModel model)
        {
            sauceModel = model;
            return RedirectToAction("IngredientsPicker");
        }

        public ActionResult IngredientsPicker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IngredientsPicker(List<IngredientModel> models)
        {
            ingredientModel = models;
            return RedirectToAction("AddOrder"); 
        }

        [HttpPost]
        public ActionResult AddOrder(PizzaModel model)
        {
            var cookie = HttpContext.User.Identity.Name;
            PizzaManager.OrderPizza(Guid.Parse(cookie), model);
            return View();
        }

        public ActionResult ViewOrder()
        {
            var cookie = HttpContext.User.Identity.Name;
            var order = OrderManager.GetOrder(Guid.Parse(cookie));
            var pizzas = new List<PizzaModel>();
            foreach(var orderrule in order.OrderRules)
            {
                var model = PizzaManager.GetPizza(orderrule.Pizza.Id);
                pizzas.Add(model);
            }
            return View(pizzas);
        }

        public ActionResult OrderOrder()
        {
            return View();
        }
    }
}