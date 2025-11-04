using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.RatingsDtos
{
    public  class addRatingDtos
    {
        public int AppointmentID { get; set; }
        public int BarberID { get; set; }
        public int CustomerID { get; set; }
        public byte Score { get; set; }  // 1 - 5
        public string? Comment { get; set; }
    
    }
}
