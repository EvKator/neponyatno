using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Data.Entity
{
    public class TestCase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(2046)]
        public string Description { get; set; }

        [ForeignKey("Requirment")]
        public int RequirmentId { get; set; }

        public virtual Requirment Requirment { get; set; }

    }
}
