using Dtos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.SpeclisysDtos
{
    public  class addSpeclistNewDtos
    {
        public string SpecilityName { get; set; }
        public string? Description { get; set; }

        public List<addServicesDtos> addServicesDtos { get; set; } = new List<addServicesDtos>();
    }
}
