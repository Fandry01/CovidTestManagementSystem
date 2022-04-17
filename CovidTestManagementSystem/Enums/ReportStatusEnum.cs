using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Enums
{
    public enum ReportStatusEnum
    {
        Default = 0,
        Unassigned = 1,
        Assigned = 2,
        Analyzed = 3,
        Finished = 4,
    }
}
