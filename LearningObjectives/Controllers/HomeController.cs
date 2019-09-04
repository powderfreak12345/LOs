using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningObjectives.Models;

namespace LearningObjectives.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //  This is presumably how the HomeController is supposed to be modified to support the Course view.
        public IActionResult Course()
        {
            return View();
        }

        //  This is presumably how the HomeController is supposed to be modified to support the Overview view.
        public IActionResult Overview()
        {
            return View();
        }

        //  This is presumably how the HomeController is supposed to be modified to support the Unimplemented Page view.
        public IActionResult UnimplementedPage()
        {
            return View();
        }

        
        //  This is presumably how the HomeController is supposed to be modified to support the Layout Experiments view.
        public IActionResult LayoutExperiments()
        {
            return View();
        }
    }
}
