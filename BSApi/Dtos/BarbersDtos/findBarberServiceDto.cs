using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BarbersDtos
{
    public  class findBarberServiceDto
    {
        public int BarberServiceID {  get; init; }
        public short ServiceDetilasID { get; init; }
        public int barberID { get; init; }
        public bool Enabled {  get; init; }
        public decimal Price { get; init; }
        public TimeSpan Duration { get; init; }
    }
}
