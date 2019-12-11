using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Data.Entity.Enum
{
    public enum TestCaseType
    {
        [Display(Name = "Тестування графічного інтерфейсу")]
        UI,
        [Display(Name = "Тестування безпеки")]
        SECURITY,
        [Display(Name = "Тестування логіки")]

        LOGIC
    }
}
