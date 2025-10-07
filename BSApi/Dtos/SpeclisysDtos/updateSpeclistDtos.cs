using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.SpeclisysDtos
{
    public  class updateSpeclistDtos
    {
        public short SpecilityID { get; set; }
        public string SpecilityName { get; set; }
        public string? Description { get; set; }
    }
}
