using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Data.Entity
{
    public class Requirment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Назва вимоги")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Display(Name = "Опис вимоги")]
        public string Description { get; set; }

        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }

        public virtual Specification Specification { get; set; }

        public virtual ICollection<TestCase> TestCases { get; set; }
    }
}
