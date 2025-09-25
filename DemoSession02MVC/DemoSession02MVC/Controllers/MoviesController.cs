using DemoSession02MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DemoSession02MVC.Controlers
{
    public class MoviesController : Controller
    {
        //[NonAction] secret
        public string Index()
        {
            return $"Hello From Index";

        }

        #region Ex01
        //[HttpGet]
        //public ContentResult GetMovie(int? id, string name)
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.Content = $"movie {id} <br> {name}";    //Old way
        //    //result.ContentType = "text/html";
        //    //return result;

        //    return Content($"movie {id} <br> {name}", "text/html");
        //}
        #endregion

       #region EX02
        [HttpGet]
        public IActionResult GetMovie(int? id, string name)
        {
            if (id == 0) return BadRequest();
            else if (id <10) return NotFound();
            else return Content($"movie {id} <br> {name}", "text/html");


        }
        [HttpGet]
        public IActionResult TestRedirectToAction()
        {
            return Redirect("GetMovie");                          //same controller
            //return Redirect("GetMovie",//controller name);       //different controller
            //return Redirect("https://localhost:7045/movies/GetMovie?id=52&name=mm");
        }


        #endregion
        [HttpPost]
        public IActionResult TestModelBinding([FromQuery]int?id ,[FromRoute] string name)
        {
            return Content($"Hello {name} your id is {id}");
        }


        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            if (movie== null)
                return BadRequest();
            else return Content($"Hello {movie.Title} your id is {movie.Id}");

        }
        }
}
