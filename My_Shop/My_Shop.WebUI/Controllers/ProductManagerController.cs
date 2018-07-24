using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Shop.DataAccess.InMemory;
using My_Shop.Core.Models;

namespace My_Shop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository contex = null;

        public ProductManagerController()
        {
            MyShopEntities bgt = new MyShopEntities();
            ProductRepository contex = new ProductRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = contex.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                contex.Insert(product);
                contex.Commit();
                return RedirectToAction("Index");
            }
        }
        
        public ActionResult Edit(int Id)
        {
            Product product = contex.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, int Id)
        {
            Product productToEdit = contex.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productToEdit.Description = product.Description;
                productToEdit.Category = product.Category;
                productToEdit.Name = product.Name;
                productToEdit.Prize = product.Prize;
                productToEdit.Id = product.Id;
                productToEdit.Image = product.Image;

                contex.Commit();

                return RedirectToAction("Index");


            }
        }
        public ActionResult Delete(int Id)
        {
            Product productToDelete = contex.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Product productToDelete = contex.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                contex.Delet(Id);
                return RedirectToAction("Index");
            }
        }
    }
}