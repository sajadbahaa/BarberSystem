using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class addApplicationDtos
    {
        public int UserID { get; set; }
        public string Shop { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string CopyFirstName { get; set; } = string.Empty;
        public string CopySecondName { get; set; } = string.Empty;
        public string CopyLastName { get; set; } = string.Empty;
        public string? CopyPhone { get; set; } = null;

        public List<addTempBarberServiceDtos> addTempBarberServiceDtos { get; set; } = new List<addTempBarberServiceDtos>();
    
    
    }
}
