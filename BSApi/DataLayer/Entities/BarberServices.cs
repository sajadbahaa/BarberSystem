using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class BarberServices
    {
public int BarberServiceID{ get; set; }
public int BarberID { get; set; } 
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public short ServiceDetilasID { get; set; }
        public ServicesDetials ServicesDetials { get; set; } = null!;
        public Barbers barbers { get; set; } = null!;
        public bool Enabled {  get; set; }  
    }
}
