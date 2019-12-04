using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Data.Entity
{
    public class ApplicationUser: IdentityUser<string>
    {
        [PersonalData,  StringLength(20)]
        public string FirstName { get; set; }

        [PersonalData, StringLength(20)]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
