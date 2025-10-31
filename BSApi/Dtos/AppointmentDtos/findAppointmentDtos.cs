using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.AppointmentDtos
{

    public  class  findAppointmentDtos
    {
        public int AppointmentID { get; init; }
        public int CustomerID { get; init; }
        public int BarberServiceID { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public string Status { get; init; }
        public string? Note { get; init; }
    }

}
