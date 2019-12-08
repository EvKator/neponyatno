using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity;

namespace WebApplication6.Models
{
    public class StudentLabaMapper
    {
        public StudentLabaDTO ToDto(Laba laba)
        {
            StudentLabaDTO studentLabaDTO = new StudentLabaDTO()
            {
                LabaCases = laba.LabaCases.Select(a=> new LabaCaseDto()
                {
                    Requirment = a.Requirment,
                    TestCase = a.TestCase
                }
                ).ToList(),
                Specification = laba.Specification
            };
            return studentLabaDTO;
        }

        public IList<StudentLabaDTO> ToDto(IEnumerable<Laba> labas)
        {
            return labas.Select(a => ToDto(a)).ToList();
        }
    }
}
