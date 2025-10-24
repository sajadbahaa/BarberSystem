using Dtos.PeopleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BarbersDtos
{
    public  class updateBarberPersonDto
    {
        public int BarberID { get; init; }
        public string ShopName { get; set; } = null!;
        public string Location { get; set; } = null!;

        public UpdatePeopleDtos peopleDtos { get; set; } = null!;
    }
}
