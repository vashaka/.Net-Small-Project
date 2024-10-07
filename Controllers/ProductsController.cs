using Market.Data;
using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class ProductsController(ApplicationDbContext db) : Controller
    {
        private readonly ApplicationDbContext _db = db;

        public IActionResult Index()
        {
            List<Product> Products = _db.Products.ToList();
            return View(Products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(newProduct);
                _db.SaveChanges();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Product foundProduct = _db.Products.FirstOrDefault(p => p.Id == Id)!;
            if (foundProduct != null)
            {
                _db.Products.Remove(foundProduct);
                _db.SaveChanges();
                TempData["success"] = "Product Deleted Successfully!";
                return RedirectToAction("Index");
            }
            return View("Index");
        }

    }
}