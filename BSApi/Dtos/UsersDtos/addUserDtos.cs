using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UsersDtos
{
    public  class addUserDtos
    {
    public  string ?  PasswordHash { get; set; }
        public string UserName { get; set; } = null!;
        public string ? Email { get; set; }
    public DateTime CreateAt { get; set; }

}
}
