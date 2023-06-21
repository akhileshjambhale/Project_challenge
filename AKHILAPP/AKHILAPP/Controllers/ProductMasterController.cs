using AKHILAPP.Data;
using AKHILAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace AKHILAPP.Controllers
{
    public class ProductMasterController : Controller
    {
        private readonly AkhilAppDbcontext _context;

        public ProductMasterController(AkhilAppDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int page = 1)
        {
            int pageSize = 10;

            int totalRecords = _context.Product_Masters.Count();

            var products = _context.Product_Masters
                .OrderBy(p => p.ProdMaster_Id)
                .Include(p => p.Category_Master)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = _context.Category_Masters.ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product_Master product)
        {
            if (ModelState.IsValid)
            {
                _context.Product_Masters.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Get");
            }

            var categories = _context.Category_Masters.ToList();
            ViewBag.Categories = categories;
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            var products = _context.Product_Masters
                .OrderBy(p => p.ProdMaster_Id)
                .Include(p => p.Category_Master)
                .ToList();

            ViewBag.Products = products;

            return View();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Product_Masters.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product_Masters.Remove(product);
            _context.SaveChanges();

            TempData["Message"] = "Product deleted successfully.";

            return RedirectToAction("Delete");
        }


        [HttpGet]
        public IActionResult Update()
        {
            var products = _context.Product_Masters
                .OrderBy(p => p.ProdMaster_Id)
                .Include(p => p.Category_Master)
                .ToList();

            return View(products);
        }


        [HttpPost]
        public IActionResult Update(int id, string productName)
        {
            var product = _context.Product_Masters.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Prod_Name = productName;
            _context.SaveChanges();

            TempData["UpdateMessage"] = "Product updated successfully.";

            return RedirectToAction("Update");
        }
    }
}
