using eCommerce.Contracts;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Web.Controllers
{
    public class AdminController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;


        public AdminController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products)
        {
            this.customers = customers;
            this.products = products;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var model = products.GetAll();
            if (model == null)
                throw new ArgumentNullException();

            return View("ViewAll", model);
        }

        public ActionResult AddProduct()
        {
            return View("ProductForm");
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var prod = products.GetById(product.ProductId);
            if (prod != null)
                products.Update(product);
            else
                products.Insert(product);

            products.SaveChanges();

            return View("ViewAll", products.GetAll());
        }

        public ActionResult ViewAll()
        {
            return View(products.GetAll());
        }

        public ActionResult EditProduct()
        {
            return View("ProductForm");
        }


    }
}