using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Dto
{
    public class LeaveTypeResponseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxDaysAllowed { get; set; }
    }
}