using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity;

namespace WebApplication6.Models
{
    public class StudentLabaDTO
    {
        [Key]
        public int Id { get; set; }

        public Specification Specification { get; set; }

        public IList<LabaCaseDto> LabaCases { get; set; }
    }
}
