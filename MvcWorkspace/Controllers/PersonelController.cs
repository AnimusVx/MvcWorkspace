using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;

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
            PersonelVM personelVM = new PersonelVM();   // ViewModel obje mantığıyla çalışıyor. 
            IEnumerable<Personel> personels = _db.personels.Include(p => p.Bolum);

            // ViewBag.PersonelCount = personels.Count();
            
            //List<string> kayitlar = new List<string>();
            
            //foreach (var p in personels)
            //{
            //    kayitlar.Add($"{p.Id} - {p.Name}");
            //}
            personelVM.PersonelCount = personels.Count();
            personelVM.PersoneListe = personels;

            return View(personelVM);
            // return View(kayitlar);
            // return View(personels);
        }
    }
}
