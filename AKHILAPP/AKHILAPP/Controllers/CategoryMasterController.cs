using AKHILAPP.Data;
using AKHILAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AKHILAPP.Controllers
{
    public class CategoryMasterController : Controller
    {
        private readonly AkhilAppDbcontext _context;

        public CategoryMasterController(AkhilAppDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int page = 1)
        {
            int pageSize = 10;

            int totalRecords = _context.Category_Masters.Count();

            var categories = _context.Category_Masters
                .OrderBy(c => c.CatMaster_Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;


            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category_Master category)
        {
            if (ModelState.IsValid)
            {
                _context.Category_Masters.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Get");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            var categories = _context.Category_Masters
                .OrderBy(c => c.CatMaster_Id)
                .ToList();

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Category_Masters.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category_Masters.Remove(category);
            _context.SaveChanges();

            TempData["Message"] = "Category deleted successfully.";

            return RedirectToAction("Delete");
        }

        [HttpGet]
        public IActionResult Update()
        {
            var categories = _context.Category_Masters
                .OrderBy(c => c.CatMaster_Id)
                .ToList();

            return View(categories);
        }

        [HttpPost]
        public IActionResult Update(int id, string categoryName)
        {
            var category = _context.Category_Masters.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            category.Cat_Name = categoryName;
            _context.SaveChanges();

            TempData["UpdateMessage"] = "Category updated successfully.";

            return RedirectToAction("Update");
        }
    }
}
