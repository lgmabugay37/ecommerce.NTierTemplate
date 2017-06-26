using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        public string Address { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
    }
}
