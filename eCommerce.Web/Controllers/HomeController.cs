using eCommerce.Contracts;
using eCommerce.Model;
using eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<BasketItem> basketItems;

        BasketService basketService;

        public HomeController(IRepositoryBase<Customer> customers, 
                              IRepositoryBase<Product> products,
                              IRepositoryBase<Basket> baskets
                              
            
                                )
        {
            this.customers = customers;
            this.products = products;
            this.basketService = new BasketService(this.baskets);
        }

        public ActionResult Index()
        {
            var model = products.GetAll();

            return View(model);
        }

        public ActionResult AddToBasket(int ProductId)
        {
            basketService.AddToBasket(this.HttpContext, ProductId, 1);
            return RedirectToAction("BasketSummary");
        }

        public ActionResult BasketSummary()
        {
            var model = basketService.GetBasket(this.HttpContext);

            return View(model.BasketItems);
        }

    }
}