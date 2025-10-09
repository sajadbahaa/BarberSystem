using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UsersDtos
{
    public  class ChangePasswordDto
    {
        public int UserId { get; init; } 
        public string CurrentPassword { get; init; } = string.Empty;
        public string? Password { get; set; }
    }
}
