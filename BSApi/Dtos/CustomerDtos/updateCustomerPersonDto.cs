using Dtos.PeopleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dtos.CustomerDtos
{
    public  class updateCustomerPersonDto
    {
        [JsonIgnore]
        public int userID {get; set; }
        public UpdatePeopleDtos peopleDtos { get; set; } = null!;
    }
}
