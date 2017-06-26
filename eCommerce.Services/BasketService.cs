using eCommerce.Contracts;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Services
{
    public class BasketService
    {
        public IRepositoryBase<Basket> baskets;
        public const string BasketSessionName = "ecommerceBasket";

        public BasketService(IRepositoryBase<Basket> baskets)
        {
            this.baskets = baskets;
        }

        private Basket CreateNewBasket(HttpContextBase httpContext)
        {
            HttpCookie cookie = new HttpCookie(BasketSessionName);

            var basket = new Basket()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,

            };


            baskets.Insert(basket);
            baskets.SaveChanges();

            cookie.Value = basket.Id.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }

        public bool AddToBasket(HttpContextBase httpContext, int productId, int quantity)
        {
            bool success = true;

            Basket basket = GetBasket(httpContext);
            BasketItem item = basket.BasketItems.FirstOrDefault(e => e.ProductId == productId);

            if (item == null)
            {
                item = new BasketItem()
                {
                    BasketId = basket.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                basket.BasketItems.Add(item);
            }
            else
            {
                item.Quantity = item.Quantity + quantity;
            }

            baskets.SaveChanges();



            return success;
        }

        public Basket GetBasket(HttpContextBase httpContext)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
            Basket basket;
            Guid basketId;

            if (cookie != null)
            {
                if (Guid.TryParse(cookie.Value, out basketId))
                {
                    basket = baskets.GetById(basketId);
                }
                else
                {
                    basket = CreateNewBasket(httpContext);
                }
            }
            else
            {
                basket = CreateNewBasket(httpContext);
            }


            return basket;
        }
    }
}
