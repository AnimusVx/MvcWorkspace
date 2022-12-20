using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;
using System.Collections.Generic;

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
            IEnumerable<Expense> Expenses = _db.Expenses;
            foreach (var expense in Expenses)
            {
                expense.ExpenseCategory = _db.ExpenseCategories.Find(expense.C_Id);
            }
            // Eager Loading 
            IEnumerable<Expense> ExpenseList = _db.Expenses.Include(u => u.ExpenseCategory);
            return View(Expenses);
        }

        public IActionResult Delete(int id)
        {
            var expense = _db.Expenses.Find(id);
            if (expense == null || id == 0) return NotFound();
            _db.Expenses.Remove(expense);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddOrUpdate(int id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                ExpenseCat = _db.ExpenseCategories.Select(x => new SelectListItem { Value = x.C_Id.ToString(), Text = x.ExpenseCName })
            };
            
            // ViewBag.ExpenseCat = ExpenseCat;
            if (id == 0)
            {
                return View(expenseVM);
            }
            else
            {
                expenseVM.Expense = _db.Expenses.Find(id);
                return View(expenseVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Expense expense)
        {
                if (expense.Id == 0)
                {
                    _db.Add(expense);
                }
                else
                {
                    _db.Update(expense);
                }
                _db.SaveChanges();

                return RedirectToAction("Index");
        }

        // GET
        public IActionResult CategoryExpenses(int cid)
        {

            ViewBag.Amounts = 0;
            IEnumerable<Expense> Expenses = _db.Expenses.Where(x => x.C_Id == cid);
            ViewBag.catName = _db.ExpenseCategories.Find(cid).ExpenseCName;
            GetTotal(Expenses);
            return View(Expenses);
            
        }
        private void GetTotal(IEnumerable<Expense> list)
        {
            ViewBag.Amounts = 0;
            foreach (var exp in list) ViewBag.Amounts += exp.Amount;
        }
    }
}
