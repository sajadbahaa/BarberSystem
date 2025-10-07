using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class Speclitys
    {
        public short SpecilityID { get; set; }
        public string SpecilityName { get; set; }
        public string ? Description { get; set; }
        public bool Enabled { get; set; }
        public ICollection<ServicesDetials> ServicesDetials { get; set; } = new List<ServicesDetials>();

        public Speclitys() 
        {
            SpecilityID = 0;
            SpecilityName = string.Empty;
            Description = string.Empty;
            Enabled = true;
        }
    }
}
