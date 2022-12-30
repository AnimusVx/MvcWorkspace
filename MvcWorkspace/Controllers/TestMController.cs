using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class TestMController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public TestMController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TestM testM, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_env.WebRootPath, @"images\test");
                var extension = Path.GetExtension(fileName);

                if(testM.ImgUrl != null)
                {
                    var oldImagePath = Path.Combine(_env.WebRootPath, testM.ImgUrl);
                    if(System.IO.File.Exists(oldImagePath)) 
                    { 
                        
                    }
                }
               
            }
            return RedirectToAction("Index");
        }
    }
}
