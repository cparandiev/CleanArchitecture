using System.Collections.Generic;

namespace Web.Models.BindingModels
{
    public class DoctorWeeklyWorkingTimeBm
    {
        public int? NumOfWeeks { get; set; }

        public IEnumerable<WorkingTimeBm> WorkingTimes { get; set; }
    }
}
