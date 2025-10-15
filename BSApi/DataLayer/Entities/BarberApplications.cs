using DataLayer.Entities.EnumClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class BarberApplications
    {
        public int ApplicationID { get; set; }
        public int UserID { get; set; }
        public int ? PersonID { get; set; }
        public People ? person { get; set; }
        public DateOnly CreatAt { get; set;}
        public DateOnly?  UpdateAt { get; set; }
        public string ? Reason { get; set; }
        public string  Shop { get; set; }
        public string Location { get; set; }
        public string CopyFirstName { get; set; }
        public string CopySecondName { get; set; }
        public string CopyLastName { get; set; }
        public string? CopyPhone { get; set; }
        public AppUser user { get; set; }
        public enApplicationStatus Status { get; set; }

        public ICollection<TempBarberServices>? TempBarberServices { get; set; } = new List<TempBarberServices>();
        public ICollection<ApplicationsHistory>? applicationsHistories{ get; set; } = new List<ApplicationsHistory>();

        public BarberApplications()
        {
            ApplicationID = 0;
            UserID = 0;
            PersonID = null;
            Shop = string.Empty;
            Location = string.Empty;
            CopyFirstName = string.Empty;
            CopySecondName = string.Empty;
            CopyLastName = string.Empty;
            //CopyPhone = string.Empty;
            Status = enApplicationStatus.Draft;
            CreatAt = DateOnly.FromDateTime(DateTime.Now);
        }

    }
}
