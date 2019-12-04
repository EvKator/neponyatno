using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Data.Entity
{
    public class LabaCase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("TestCase")]
        public int TestCaseId { get; set; }

        [ForeignKey("Requirment")]
        public int RequirmentId { get; set; }

        [ForeignKey("Laba")]
        public int LabaId { get; set; }

        [Required]
        public virtual TestCase TestCase { get; set; }

        public virtual Requirment Requirment { get; set; }

        public Laba Laba { get; set; }
    }
}
