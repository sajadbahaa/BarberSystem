using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class Barbers
    {
        public int BarberID { get; set; }
        public int PersonID {  get; set; }
        public string ShopName { get; set; } = null!;
        public decimal Rating { get; set; }
        public string Location { get; set; } = null!;
        public int UserID { get; set; }
        public People people { get; set; } = null!;
        public AppUser user { get; set; } = null!;
        public ICollection<BarberServices> BarberServices { get; set; }
        public ICollection<Ratings>? ratings { get; set; }
        public Barbers()
        {
            Rating = 0;
        }
    }
    }

