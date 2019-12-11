using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;
using WebApplication6.Data.Entity;

namespace WebApplication6.Services.Impl
{
    public class LabaCheckerService : ILabaCheckerService
    {
        private ApplicationDbContext _context;

        public LabaCheckerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public uint Check(Laba laba)
        {
            Specification specification = laba.Specification;
            uint right = 0;
            foreach(LabaCase labaCase in laba.LabaCases)
            {
                if (ContainsRightAnswer(specification, labaCase))
                {
                    right++;
                    labaCase.RightAnswer = true;
                }
                else
                {
                    labaCase.RightAnswer = false;
                }
            }
            if (specification.QuestionsPerStudent <= 0)
                return 100;
            return Convert.ToUInt32(100 * (double)right / (double)(specification.QuestionsPerStudent > laba.LabaCases.Count? laba.LabaCases.Count:  specification.QuestionsPerStudent));
        }

        public void CheckAll()
        {
            var labas =  _context.Labas
                .Include(l => l.Student)
                .ToList();
            foreach (Laba laba in labas)
            {
                Specification specification = laba.Specification;

            }
            throw new NotImplementedException();
        }

        public bool IsRightAnswer(IEnumerable<TestCase> testCases, LabaCase labaCase)
        {
            var testCase = testCases.Where(t => t.Id == labaCase.TestCaseId).FirstOrDefault();
            return testCase.RequirmentId == labaCase.RequirmentId && testCase.TestCaseType == labaCase.TestCaseType;
        }

        public bool ContainsRightAnswer(Specification specification, LabaCase labaCase)
        {
            var testCases = specification.Requirments.SelectMany(a => a.TestCases).ToList();
            return IsRightAnswer(testCases, labaCase);
        }

        public int Check(ILabaCheckerService laba)
        {
            throw new NotImplementedException();
        }
    }
}
