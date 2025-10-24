using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BarbersDtos
{
    public  class findBarberDtos
    {
        public int BarberID { get; init; }
        public string FullName { get; init; }
        public string ShopName { get; init; } = null!;
        public decimal Rating { get; init; }
    }
}
