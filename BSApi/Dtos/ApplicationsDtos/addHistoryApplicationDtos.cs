using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class addHistoryApplicationDtos
    {
        public int UserID        { get; init; }
        public int ApplicationID { get;  init; }
        public string? Notes     { get; init; }
    }
}
