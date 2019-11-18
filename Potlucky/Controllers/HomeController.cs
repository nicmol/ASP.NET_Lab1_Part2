using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Potlucky.Models;


namespace Potlucky.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
               

        public IActionResult History()
        {
            return View();
            
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult People()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }
        
        // StatusCode method returns 404 to NotFoundExample method with a type of StatusCodeResult 
        public StatusCodeResult NotFoundExample()
        {
            return StatusCode(404);
        }

        //Method returns a 204 http status code of NoContentResult type
        public NoContentResult NoContentExample()
        {
            return NoContent();
        }

        //Serializes the Index view and returns it as JSON
        public JsonResult JsonExample()
        {
            return Json(View("Index"));
        }

        //String example
        public string StringExample()
        {
            return "Hello LCC";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
