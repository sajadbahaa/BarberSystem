using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ApplicationsDtos
{
    public class RejectedOrCanceledApplicarionDtos
    {
        public int ApplicatinoID { get; init; }
        public string ? Reason { get; init; }
        public int UserID {  get; init; }
    }
}
