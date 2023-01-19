using cruddd.Data;
using cruddd.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Ocsp;

namespace cruddd.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserContext context;

        public ProductController(UserContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Product.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Productlist model)
        {
            if (ModelState.IsValid)
            {
                var pro = new Productlist()
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                };
                context.Product.Add(pro);
                context.SaveChanges();
                TempData["error"] = "Record Saved...!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "empty fields";
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            var pro = context.Product.SingleOrDefault(e => e.ProductId == id);
            context.Product.Remove(pro);
            context.SaveChanges();
            TempData["error"] = "Record deleted...!";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var pro = context.Product.SingleOrDefault(e => e.ProductId == id);
            var result = new Productlist()
            {
                ProductId = pro.ProductId,
                ProductName = pro.ProductName,
                CategoryId = pro.CategoryId,
                CategoryName = pro.CategoryName,
            };

            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Productlist model)
        {
            var pro = new Productlist()
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
            };
            context.Product.Update(pro);
            context.SaveChanges();
            TempData["error"] = "Record Updated...!";
            return RedirectToAction("Index");
        }
    }
}



      