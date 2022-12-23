using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class TestMController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiforgeryToken]
        public IActionResult Upsert(TestM testM, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                fileName = 
            }
            return RedirectToAction("Index");
        }
    }
}
