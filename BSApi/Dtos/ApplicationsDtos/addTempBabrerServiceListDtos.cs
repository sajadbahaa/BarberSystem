using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class addTempBabrerServiceListDtos
    {
        public int ApplicationID { get; set; }
        public int useriD { get; set; }
        public List<addTempBarberServiceSingleDtos> AddTempBarberServiceList { get; set; } = null!; 
    }
}
