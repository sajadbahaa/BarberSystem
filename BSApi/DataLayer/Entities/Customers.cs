using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class Customers
    {
        public int CustomerID { get; init; }
        public int PersonID { get; set; }
        public int UserID { get; set; }
        public AppUser user { get; set; }
        public People person {  get; set; }
        public ICollection<Appointments>? appointments { get; set; }
        public ICollection<Ratings>? ratings { get; set; }
        public Customers()
        {
            CustomerID = 0;
            PersonID = 0;
        }
    }
}
