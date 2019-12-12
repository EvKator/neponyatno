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
        [Display(Name = "Назва специфіцкації")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Display(Name = "Опис специфікації")]
        public string Description { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Питань для студента")]
        public int QuestionsPerStudent { get; set; }

        public DateTime LastUpdateAt { get; set; }

        [Display(Name = "Автор")]
        public virtual ApplicationUser Author { get; set; }

        [Display(Name = "Вимоги для специфікації")]
        public virtual IList<Requirment> Requirments { get; set; }

        public virtual IList<Laba> Labas { get; set; }

        public Specification()
        {
            LastUpdateAt = DateTime.Now;
        }

    }
}
