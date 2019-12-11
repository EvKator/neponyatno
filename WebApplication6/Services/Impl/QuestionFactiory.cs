using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity;

namespace WebApplication6.Services.Impl
{
    public class QuestionFactiory : IQuestionsFactory
    {
        public ICollection<TestCase> CreateQuestions(Specification specification)
        {
            Random random = new Random();

            List<TestCase> testCases1 = specification.Requirments.SelectMany(a=>a.TestCases).ToList();

            if (specification.QuestionsPerStudent >= testCases1.Count)
                return testCases1;

            ISet<TestCase> testCases = new HashSet<TestCase>();

            while(testCases.Count < specification.QuestionsPerStudent)
            {
                int i = random.Next(0, testCases1.Count);
                testCases.Add(testCases1[i]);
            }
            return testCases1;
        }
    }
}
