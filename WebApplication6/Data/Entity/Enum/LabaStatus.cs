using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Data.Entity.Enum
{
    public enum LabaStatus
    {
        [Display(Name ="Save")]
        SAVED,

        [Display(Name = "Submitted")]
        SUBMITTED,
        CHECKED,
        READY_FOR_REVIEW
    }
}
