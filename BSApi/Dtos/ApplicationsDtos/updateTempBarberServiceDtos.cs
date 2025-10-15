using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class updateTempBarberServiceDtos
    {
        public short TempServiceID { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
 
    public updateTempBarberServiceDtos()
        {
            TempServiceID = 0;
            Price = 0;
            Duration = TimeSpan.FromHours(10);
        }
    }
}
