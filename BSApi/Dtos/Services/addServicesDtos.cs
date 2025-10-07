using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Services
{
    public  class addServicesDtos
    {

        public string ServiceName { get; set; }
        public decimal price { get; set; }
        public TimeSpan duration { get; set; }
    }
}
