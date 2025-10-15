using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class updateFullApplicationDtos
    {

        public updateApplicationDtos UpdateApplicationDtos { get; set; } = null!;// optional
        public List<updateTempBarberServiceDtos> ServicesUpdate { get; set; } // optional
        public List<int> ServicesToDelete { get; set; } // optional
        public List<addTempBarberServiceDtos> AddTempBarberServiceDtos { get; set; } // optional
    
    public updateFullApplicationDtos()
        {
            ServicesToDelete =  new List<int>();
            ServicesUpdate = new List<updateTempBarberServiceDtos>();
            AddTempBarberServiceDtos = new List<addTempBarberServiceDtos>();
        }
    }
}
