using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantContext _db;

    public RestaurantsController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants
                            .Include(restaurant => restaurant.Cuisine)
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      Dictionary<int, string> PriceOptions = new Dictionary<int, string>() { 
        {1, "$"}, 
        {2, "$$"}, 
        {3, "$$$"},
        {4, "$$$$"},
        {5, "$$$$$"} };
      ViewBag.Price = new SelectList(PriceOptions, "Value", "Value");
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Type");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      if (restaurant.CuisineId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult Details(int id)
    // {
    //   // Item thisItem = _db.Items
    //   //                     .Include(item => item.Category)
    //   //                     .FirstOrDefault(item => item.ItemId == id);
    //   return View(thisItem);
    // }

    // public ActionResult Edit(int id)
    // {
    //   // Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //   // ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View(thisItem);
    // }

    // [HttpPost]
    // public ActionResult Edit(Item item)
    // {
    //   // _db.Items.Update(item);
    //   // _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   // Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //   return View(thisItem);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   // Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //   // _db.Items.Remove(thisItem);
    //   // _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}