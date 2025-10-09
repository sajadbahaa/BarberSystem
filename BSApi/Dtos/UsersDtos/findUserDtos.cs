using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UsersDtos
{
    public  class findUserDtos
    {
        public int Id { get; init; } 
        public string Email { get;
        init; }
        public string UserName { get; init; } = null!;
        public string IsActive { get; set; }
    }
}
