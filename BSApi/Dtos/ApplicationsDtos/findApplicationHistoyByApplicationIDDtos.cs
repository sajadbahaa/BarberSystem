using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class findApplicationHistoyByApplicationIDDtos
    {
        public int ApplicationID { get; init; }
        public List<findApplicationHistotyDtos> HistoyListsDtos{ get; init; } = new();
    }
}
