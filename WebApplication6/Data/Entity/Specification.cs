using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Data.Entity
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [Range(1, int.MaxValue)]
        public int QuestionsPerStudent { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual IList<Requirment> Requirments { get; set; }

        public virtual IList<Laba> Labas { get; set; }

    }
}
