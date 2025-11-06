using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class People
    {
        public int PersonID { get; set;}
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string ? Phone { get; set; }
        //public string ? Email { get; set; }
        public bool Enabled { get; set; }

        public Barbers?Barbers { get; set; }
        public Customers? Customer { get; set; }
        public BarberApplications ? BarberApplications { get; set; }
        public People()
        {
      
            FirstName = string.Empty;
            LastName = string.Empty;
            SecondName = string.Empty;
            Phone = null ;
            //Email = null ;
            Enabled = true;
        }
    }
}
