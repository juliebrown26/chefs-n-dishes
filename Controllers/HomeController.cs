using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chefsndishes.Models;

namespace chefsndishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefsDishesContext DbContext;
        public HomeController(ChefsDishesContext context)
        {
            DbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = DbContext.Chef
                .Include(Chef => Chef.CreatedDishes)
                .ToList();

            return View(AllChefs);
        }

        [HttpGet]
        [Route("new")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost]
        [Route("AddChef")]
        public IActionResult AddChef(Chef newChef)
        {
            System.Console.WriteLine("*********** new chef time **************");
            if (ModelState.IsValid)
            {
                DbContext.Add(newChef);
                DbContext.SaveChanges();
                System.Console.WriteLine("*********** adding new chef ***********");
                return RedirectToAction("Index");
            }
            return View("NewChef");
        }

        [HttpGet]
        [Route("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = DbContext.Dish
                .Include(Dish => Dish.Creator)
                .ToList();
            return View(AllDishes);
        }

        [HttpGet]
        [Route("dishes/new")]
        public IActionResult NewDish()
        {
            NewDishViewModel model = new NewDishViewModel()
            {
                Chefs = DbContext.Chef.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [Route("dishes/AddDish")]
        public IActionResult AddDish(NewDishViewModel newModel)
        {
            if (ModelState.IsValid)
            {
                DbContext.Add(newModel.NewDish);
                DbContext.SaveChanges();
                System.Console.WriteLine("*********** adding new dish ************");
                return RedirectToAction("Dishes");
            }
            return View("NewDish");
        }
    }
}
