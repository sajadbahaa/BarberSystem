//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class AppUser : IdentityUser<int>
    {

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsActive { get; set;}
        
        public AppUser()
        {
            IsActive = true;
            PasswordHash = null;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
            NormalizedEmail = null;
            Email = null;
            PhoneNumberConfirmed = false;
            SecurityStamp = null;

        }
       
    }
}
