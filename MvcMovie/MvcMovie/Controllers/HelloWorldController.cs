using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            //return "This is my default action...";
            // add a view

            return View();
        }

        // GET: /HelloWorld/Welcome?name=&numTimes=4
        public IActionResult Welcome(string name, int numTimes = 1)
        {

            //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");

            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

    }
}
