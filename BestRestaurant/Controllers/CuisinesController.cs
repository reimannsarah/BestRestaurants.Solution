using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantContext _db;

    public CuisinesController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      // Category thisCategory = _db.Categories
      //                             .Include(category => category.Items)
      //                             .FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult Edit(int id)
    {
      // Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      // _db.Categories.Update(category);
      // _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      // Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      // Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      // _db.Categories.Remove(thisCategory);
      // _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}