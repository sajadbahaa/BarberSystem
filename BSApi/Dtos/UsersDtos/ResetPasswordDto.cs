using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UsersDtos
{
    public  class ResetPasswordDto
    {
        public int UserId { get; init; } 
        public string NewPassword { get; set; } = string.Empty;
    }
}
