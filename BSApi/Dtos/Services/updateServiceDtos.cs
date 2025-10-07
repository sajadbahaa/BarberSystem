using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Services
{
    public  class updateServiceDtos
    {
        public short ServiceID { get; init; }
        public string ServiceName { get; set; }
        public decimal price { get; set; }
        public TimeSpan duration { get; set; }
    }
}
