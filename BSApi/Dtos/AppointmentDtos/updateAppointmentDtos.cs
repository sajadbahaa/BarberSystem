using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.AppointmentDtos
{
    public  class updateAppointmentDtos
    {

        public int AppointmentID { get; set; }
        public int CustomerID { get; set; }
        public int BarberServiceID { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Note { get; set; }
    
    }
}
