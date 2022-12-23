using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class PersonelController : Controller
    {
        private readonly AppDbContext _db;
        public PersonelController(AppDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Personel> personels = _db.personels;

            ViewBag.PersonelCount = personels.Count();
            
            List<string> names = new List<string>();
            
            foreach (var p in personels)
            {
                names.Add($"{p.Id} - {p.Name}");
            }

            return View(names);
        }
    }
}
