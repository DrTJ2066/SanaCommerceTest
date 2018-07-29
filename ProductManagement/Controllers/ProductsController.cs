using ProductManagement.Models.DAL;
using ProductManagement.Models.Models;
using ProductManagement.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductsController : Controller
    {
        private static ProductsRepository productsRepository = new ProductsRepository(new DatabaseContext());

        // GET: Products
        public ActionResult Index()
        {
            SetContextTypeInfo();
            ViewBag.ProductsCount = productsRepository.GetProductsCount();

            var result = productsRepository.GetProductsList();
            return View(result);
        }

        public ActionResult ToggleContext()
        {
            productsRepository.ToggleContext();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            productsRepository.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            SetContextTypeInfo();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.Created = DateTime.Now;
            product.Updated = null;

            productsRepository.AddNewProduct(product);

            SetContextTypeInfo();
            return RedirectToAction("Index");
        }


        private void SetContextTypeInfo()
        {
            ViewBag.ContextType = productsRepository.IsDatabaseContext ? ContextTypes.Database : ContextTypes.Memory;
        }
    }
}