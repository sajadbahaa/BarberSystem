using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class updateTempBarberServiceListDtos
    {
        public int userID { get; set; }
        public List<updateTempBarberServiceDtos> updateTempBarberServiceDto { get; set; } = null!;
    
    }
}
