using SampleMVC.Data.Models;
using SampleMVC.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVC.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        IRestaurantData db;
        public RestaurantsController(IRestaurantData restaurantData)
        {
            this.db = restaurantData;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var item = db.Get(id);
            if(item == null)
            {
                return View("NotFound");
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            /*if (string.IsNullOrWhiteSpace(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "Name is required");
            }*/
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                TempData["Message"] = "Successfully saved the Restaurant!";
                return RedirectToAction("Details", new { id = restaurant.Id } );
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var restaurant = db.Get(id);
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var restaurant = db.Get(id);
            if(restaurant == null)
            {
                return View("Not Found");
            }
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}