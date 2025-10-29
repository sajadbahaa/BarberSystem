using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dtos.BarbersDtos
{
    public  class addBarberServiceDto
    {
        [JsonIgnore]
        public int BarberID { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public short ServiceDetilasID { get; set; }

    }
}
