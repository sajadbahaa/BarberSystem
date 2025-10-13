using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class addTempBarberServiceDtos
    {
        public int ApplicationID { get; set; }
        public short ServiceDetilasID { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
