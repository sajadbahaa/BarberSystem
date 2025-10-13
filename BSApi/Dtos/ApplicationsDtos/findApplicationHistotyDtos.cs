using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class findApplicationHistotyDtos
    {
        public int HistoryID { get;   init  ; }
        public int ApplicationID { get; init ; }    
        public int UserID { get; init   ; }
        public string? Notes { get; init; }
        public string Status { get; init; }

    }
}
 
