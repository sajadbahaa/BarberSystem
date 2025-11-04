using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class DeleteTempBarberServiceDto
    {
        public List<int> tempBabrerServicesIDs { get; set; } = null!;
        
        public int userID { get; set; }
        public int ApplicationID { get; set; }
    }
}
