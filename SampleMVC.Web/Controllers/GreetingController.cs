using SampleMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVC.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            model.Message = ConfigurationManager.AppSettings["GreetingMesage"];
            model.Name = name ?? "Default Name";
            return View(model);
        }
    }
}