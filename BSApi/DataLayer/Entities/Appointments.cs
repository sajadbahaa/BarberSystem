using DataLayer.Entities.EnumClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class Appointments
    {
        public int AppointmentID {  get; set; }
        public int CustomerID {  get; set; }
        public int BarberServiceID {  get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public enApplicationStatus status { get; set; }
        public string ? Note { get; set; }
        public Customers customer { get; init; }
        public BarberServices barberServices { get; set; }
        public Ratings? ratings { get; set; }

        public Appointments()
        {
            StartDate = DateTime.Now;
            status =  enApplicationStatus.Draft;
        }
    }
}
