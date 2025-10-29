using Dtos.PeopleDtos;
using Dtos.UsersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dtos.CustomerDtos
{
    public class addCustomerPersonDto
    {
        [JsonIgnore]
        public int customerID {  get; set; }
        public int UserID {  get; set; }
        [JsonIgnore]
        public int personID {  get; set; }  
        public AddPeopleDtos peopleDtos { get; set; } = null!;
        public  addUserDtos user { get; set; } = null!;
    }
}
