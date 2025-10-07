using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Services
{
    public  class findServicesDetialsDtos
    {
        public short ServiceID { get; init; }
        public short SpeclizeID { get; init; }
        public string ServiceName { get; init; }
        public decimal price { get; init; }
        public TimeSpan duration { get; init; }
        public string Enabled { get; init; }
    }
}
