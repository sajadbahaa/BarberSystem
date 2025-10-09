using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UsersDtos
{
    public  class UserRolesDto
    {
        public int UserId { get; init; } 
        public string UserName { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
    }
}
