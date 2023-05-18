using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
    public class HomeController : Controller
    {

      private readonly BestRestaurantContext _db;

      public HomeController(BestRestaurantContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      public ActionResult SearchPrice()
      {
        ViewBag.Price = new SelectList(Restaurant.PriceOptions, "Value", "Value");
        return View();
      }

      [HttpPost]
      public ActionResult SearchPrice(string Price)
      {
        List<Restaurant> results = _db.Restaurants.Where(restaurant => restaurant.Price == Price).ToList();
        return View("Results", results);
      }

      public ActionResult Results(List<Restaurant> result)
      {
        return View(result);
      }
    }
}