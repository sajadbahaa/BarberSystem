using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class TempBarberServices
    {
        public int TempServiceID { get; set; }
        public int ApplicationID { get; set; }
        public short ServiceDetilasID { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }

        public ServicesDetials servicesDetials { get; set; }
        public BarberApplications barberApplication { get; set; }

        public TempBarberServices()
        {
            TempServiceID = 0;
            ApplicationID = 0;
            ServiceDetilasID = 0;
            Price = 0;
            Duration = TimeSpan.Zero;
        }
    }
}
