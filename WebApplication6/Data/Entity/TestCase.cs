using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity.Enum;

namespace WebApplication6.Data.Entity
{
    public class TestCase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Назва тесту")]
        public string Name { get; set; }

        [MaxLength(2046)]
        [Display(Name = "Опис тесту")]
        public string Description { get; set; }

        [ForeignKey("Requirment")]
        public int RequirmentId { get; set; }

        public TestCaseType TestCaseType { get; set; }

        public virtual Requirment Requirment { get; set; }

    }
}
