using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpensesDbContext _context;
       
        public HomeController(ILogger<HomeController> logger, ExpensesDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Expenses()
        {
            var AllExpenses=_context.Expenses.ToList();

            var totalExpenses=AllExpenses.Sum(x => x.Value);

            ViewBag.Expenses= totalExpenses;

            return View(AllExpenses);
        }
        public IActionResult CreateEditExpense(int?id)
        {
            if (id != null) 
            {
                var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
                return View(expenseInDb);
            }
           
            return View();
        }
        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }
           
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
