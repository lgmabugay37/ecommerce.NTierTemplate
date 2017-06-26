using eCommerce.Contracts;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.DAL.Data;

namespace eCommerce.DAL.Repositories
{
    public class BasketItemRepository : RepositoryBase<BasketItem>
    {
        public BasketItemRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void Save(BasketItem item)
        {
            context.BasketItems.Add(item);
            context.SaveChanges();
        }
    }
}
