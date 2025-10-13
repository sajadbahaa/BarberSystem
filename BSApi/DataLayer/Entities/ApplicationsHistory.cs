using DataLayer.Entities.EnumClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ApplicationsHistory
    {
        public int HistoryID { get; set; }
        public int UserID { get; set; }
        public int ApplicationID { get; set; }
        public enApplicationStatus Status { get; set; }
        public DateTime CreateAt { get; set; }
        public string? Notes { get; set; }
        public AppUser user { get; set; }
        public BarberApplications BarberApplication { get; set; }
        public ApplicationsHistory()
        {
            HistoryID = 0;
            UserID = 0;
            ApplicationID = 0;
            Status = enApplicationStatus.Draft;
            CreateAt = DateTime.Now;
        }

    }
}
