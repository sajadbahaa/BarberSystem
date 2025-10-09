using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.PeopleDtos
{
    public  class AddPeopleDtos
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string? Phone { get; set; }
        //public string? Email { get; set; }
        public bool Enabled { get; set; }
        public AddPeopleDtos()
        {
                 FirstName = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;
            Phone = null;
            //Email = null;
        }
    }
}
