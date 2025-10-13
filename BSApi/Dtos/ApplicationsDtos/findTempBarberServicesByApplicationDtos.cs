using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class findTempBarberServicesByApplicationDtos
    {
        public int ApplicationID { get; set; }
        public List<findTempBarberServiceGeneralDtos> TempBarberServicesDtos { get; set; } = new();
    }
}
