using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class addTempBarberServiceDtos
    {
        public short ServiceDetilasID { get; set; }
        public decimal Price { get; set; }
        
        public TimeSpan Duration { get; set; }
    
    public addTempBarberServiceDtos()
        {
            ServiceDetilasID = 0;
            Price = 0;
            Duration = TimeSpan.MinValue;
        }
    }
}
