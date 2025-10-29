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

        public ICollection<BarberApplications> ? barberApplications { get; set; } = new List<BarberApplications>();
        public ICollection<ApplicationsHistory>? applicationsHistories { get; set; } = new List<ApplicationsHistory>();
        public Barbers? Barbers { get; set; }
        public Customers?Customers { get; set; }
        // 👇 هذه العلاقة تربط المستخدم بالأدوار
        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; } = new List<IdentityUserRole<int>>();
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
