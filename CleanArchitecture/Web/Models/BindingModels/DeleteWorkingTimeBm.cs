﻿using Microsoft.AspNetCore.Mvc;

namespace Web.Models.BindingModels
{
    public class DeleteWorkingTimeBm
    {
        [FromRoute]
        public int? WorkingTimeId { get; set; }
    }
}
