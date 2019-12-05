using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity.Enum;

namespace WebApplication6.Data.Entity
{
    public class Laba
    {
        [Key]
        public int Id { get; set; }

        public LabaStatus LabaStatus { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }

        public virtual ApplicationUser Student { get; set; }
    }
}
