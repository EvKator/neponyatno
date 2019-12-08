using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity;

namespace WebApplication6.Models
{
    public class LabaCaseDto
    {
        [Key]
        public int Id { get; set; }

        public TestCase TestCase { get; set; }

        public Requirment Requirment { get; set; }
    }
}
