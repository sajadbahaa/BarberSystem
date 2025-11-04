using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class Ratings
    {
        public int RatingID { get; set; }
        public int AppointmentID { get; set; }
        public int BarberID { get; set; }
        public int CustomerID { get; set; }
        public byte Score { get; set; }  // 1 - 5
        public string? Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ? UpdateAt { get; set; }
        public Appointments appointments { get; set; }
        public Customers Customer { get; set; } = null!;
        public Barbers Barber { get; set; } = null!;
        public bool IsDelted { get; set; }
       
        public Ratings()
        {
            IsDelted = false;
            CreateAt = DateTime.Now;
        }
    }
}
