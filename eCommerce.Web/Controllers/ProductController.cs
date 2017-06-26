using eCommerce.Contracts;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        IRepositoryBase<Product> products;
        public ProductController(IRepositoryBase<Product> products)
        {
            this.products = products;
        }
        // GET: Product
        public ActionResult Details(int? ProductId)
        {
            var product = products.GetById(ProductId);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}