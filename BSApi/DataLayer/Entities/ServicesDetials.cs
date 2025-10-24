using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class ServicesDetials
    {
        public short ServiceDetilasID { get; set; }
        public short SpecilityID { get; set; }
        public short ServiceID { get; set; }
        public Servics servics { get; set; } 
        public Speclitys Speclitys { get; set; }
        public ICollection<BarberServices>? BarberServices { get; init; }
        public ICollection<TempBarberServices>? TempBarberServices { get; set; } = new List<TempBarberServices>();
        public ServicesDetials()
        {
            ServiceDetilasID = 0;   
            SpecilityID = 0;
            ServiceID = 0;
        }

    }
}
