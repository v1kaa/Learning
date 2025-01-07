using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public DiaryEntriesController(ApplicationDBContext db)
        {
            _dbContext = db; 
        }

        public IActionResult Index()
        {
            List<DiaryEntry> entriesList = _dbContext.DiaryEntries.ToList();
            return View(entriesList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title must be at least 3 characters long");
            }else if(obj != null && obj.Content.Length < 10)
            {
                ModelState.AddModelError("Content", "Content must be at least 10 characters long");
            }
            if (ModelState.IsValid)
            {
                _dbContext.DiaryEntries.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _dbContext.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
           
        }
        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title must be at least 3 characters long");
            }
            else if (obj != null && obj.Content.Length < 10)
            {
                ModelState.AddModelError("Content", "Content must be at least 10 characters long");
            }
            if (ModelState.IsValid)
            {
                _dbContext.DiaryEntries.Update(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _dbContext.DiaryEntries.Find(id);
            _dbContext.DiaryEntries.Remove(diaryEntry);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
