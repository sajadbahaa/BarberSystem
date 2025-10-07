using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class Servics
    {
        public short ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal price { get; set;}
        public  TimeSpan duration { get; set; }
        public bool Enabled { get; set; }
        public ServicesDetials servicesDetials { get; set; }
        
        public Servics()
        {
            ServiceID = 0;  
            ServiceName = string.Empty;
            price = 0;  
            duration = TimeSpan.Zero;
            Enabled = true;

        }
    }
}
