using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.SpeclisysDtos
{
    public  class findSpecliystDtos
    {
        public short SpecilityID { get; init; }
        public string SpecilityName { get; init; }
        public string? Description { get; init; }
        public string Enabled { get; init; }
    }
}
