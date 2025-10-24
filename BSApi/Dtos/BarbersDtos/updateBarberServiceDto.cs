using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BarbersDtos
{
    public  class updateBarberServiceDto
    {
        public int BarberServiceID { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
