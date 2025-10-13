using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public  class findApplicationDtos
    {
        public int ApplicationID { get; init; }
        public int UserID { get; init; }
        public string Shop { get; init; } = string.Empty;
        public string Location { get; init; } = string.Empty;
        public string CopyFirstName { get; init; } = string.Empty;
        public string CopySecondName { get; init; } = string.Empty;
        public string CopyLastName { get; init; } = string.Empty;
        public string? CopyPhone { get; init; } = null;
        public string Status { get; init; } = string.Empty;
    }
}
