using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UsersDtos
{
    public  class updateUserDtos
    {
        public int Id { get; init; } 
        public string UserName { get; init; } = null!;
        public string Email { get; init; } = null!;


    }
}
