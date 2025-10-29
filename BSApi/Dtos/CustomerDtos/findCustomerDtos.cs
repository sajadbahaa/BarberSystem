using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.CustomerDtos
{
    public  class findCustomerDtos
    {
        public int CustomerID { get; init; }
        public int personID { get; init; }
        public string FullName { get; init; } = null!;
        public int userID { get; init; }
    }
}
