using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class updateApplicationDtos
    {
        public int ApplicationID { get; set; }
        public string Shop { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string CopyFirstName { get; set; } = string.Empty;
        public string CopySecondName { get; set; } = string.Empty;
        public string CopyLastName { get; set; } = string.Empty;
        public string? CopyPhone { get; set; } = null;

        public List<updateTempBarberServiceDtos> ServicesUpdate { get; set; } = new();
        public List<int> ServicesToDelete { get; set; } = new ();
        public List<addTempBarberServiceDtos> addTempBarberServiceDtos { get; set; } = new List<addTempBarberServiceDtos>();

        public updateApplicationDtos()
        
        {
ApplicationID = 0;
            Shop = string.Empty;
            Location = string.Empty;
            CopyFirstName = string.Empty;
            CopySecondName = string.Empty;
            CopyLastName = string.Empty;
            CopyPhone = null;
        }
    }
}
