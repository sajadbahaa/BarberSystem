using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.EnumClasses
{
    public  enum enApplicationStatus
    {
        Draft = 1,
        PendingApproval = 2,
        Completed = 3,
        Canceled = 4,
        Rejected = 5,
    }
}
