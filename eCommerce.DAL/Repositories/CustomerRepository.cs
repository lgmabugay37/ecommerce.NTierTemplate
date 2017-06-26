using eCommerce.DAL.Data;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        public CustomerRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
        #region OLD CODE MOVED INTO REPOSITORY BASE
        //internal DataContext _context;

        //public CustomerRepository(DataContext context)
        //{
        //    _context = context;
        //}

        //public virtual IQueryable<Customer> GetAll()
        //{
        //    return _context.Customers;
        //}

        //public virtual Customer GetById(int customerId)
        //{
        //    return _context.Customers.Find(customerId);
        //}

        //public virtual void Insert(Customer entity)
        //{
        //    _context.Customers.Add(entity);
        //}

        //public virtual void Update(Customer entity)
        //{
        //    _context.Customers.Attach(entity);
        //    _context.Entry(entity).State = EntityState.Modified;
        //}

        //public virtual void Remove(Customer entity)
        //{
        //    if (_context.Entry(entity).State == EntityState.Detached)
        //        _context.Customers.Attach(entity);

        //    _context.Customers.Remove(entity);

        //}
        #endregion

    }
}
