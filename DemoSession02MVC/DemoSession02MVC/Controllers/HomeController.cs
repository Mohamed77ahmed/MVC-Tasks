using DemoSession02MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession02MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View();                               //return view with the same name of action
            //return View("index");                        //return view with specific name
            //return View("index",new Movie());            //return view with specific name and model name

            return View();
             
        }
    }
}
