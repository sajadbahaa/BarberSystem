using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class findTempBarberServiceGeneralDtos
    {
        public int TempServiceID { get; init; }
        public short ServiceDetilasID { get; init; }
        public decimal Price { get; init; }
        public TimeSpan Duration { get; init; }
    }
}
