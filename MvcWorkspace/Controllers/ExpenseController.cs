using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _db;

        public ExpenseController(AppDbContext db)
        { 
          _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> expenses  = _db.Expenses;
            return View(expenses);
        }
        public IActionResult Delete(int id) 
        {
            var expense = _db.Expenses.Find(id);
            if(expense == null || id == 0)
            {
                ViewData["Title"] = "hata";
                return NotFound();
            }
            ViewData["Title"] = "hata değil";

            _db.Expenses.Remove(expense);
            _db.SaveChanges ();
            return RedirectToAction("Index");
        }
        public IActionResult AddOrUpdate(int id) 
        {
            if(id == 0)
            {
                //Add
                return View(new Expense());
            }
            else
            {
                //Update
                var obj = _db.Expenses.Find(id);
                return View(obj);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Expense expense)
        {
            if(ModelState.IsValid) 
            { 
                if(expense.Id == 0)
                {
                    //Add db 
                    _db.Expenses.Add(expense);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    //Update db
                    _db.Expenses.Update(expense);
                    _db.SaveChanges();  
                }
                
            }
            return View(expense);
        }
    }
}
