using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity.Enum;

namespace WebApplication6.Data.Entity
{
    public class LabaCase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TestCase")]
        public int? TestCaseId { get; set; }

        [ForeignKey("Requirment")]
        public int? RequirmentId { get; set; }

        public TestCaseType TestCaseType { get; set; }

        [ForeignKey("Laba")]
        public int LabaId { get; set; }

        public bool? RightAnswer { get; set; }

        public virtual TestCase TestCase { get; set; }

        public virtual Requirment Requirment { get; set; }

        public Laba Laba { get; set; }
    }
}
