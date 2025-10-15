using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class updateFullApplicationRejectedDtos
    {
        public updateApplicationDtos UpdateApplicationDtos { get; set; } = null!; // optional
        public List<updateTempBarberServiceDtos> ServicesUpdate { get; set; } = null!; // optional
        public string? Note { get; set; } // optional        
    }
}
